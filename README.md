
API Usage
=========

To access Beey API, you need credentials first. Create an account at editor.beey.io. Your credentials are your e-mail and password that you use to log in Beey editor. The server URL is https://editor.beey.io/

<details>
<summary>Click here to see example usage script in python</summary>

```py
#!/usr/bin/python3
import requests
import json
import argparse
import os
import time
import sys

def load_credentials():
    try:
        with open('credentials.txt') as credentials:
            server = next(credentials)[:-1]
            email = next(credentials)[:-1]
            password = next(credentials)[:-1]
    except Exception:
        print('failed to read credentials')
        print('create file credentials.txt containing three lines: server address, email, password')
        sys.exit(1)
    return [server, email, password]

def login(server, email, password):
    url = server + '/API/Login'

    querystring = {'email':email, 'password':password}

    payload = ''
    headers = {
        'cache-control': 'no-cache',
    }

    response = requests.request('POST', url, data=payload, headers=headers, params=querystring)
    if response.status_code != 200:
        print('login failed' + str(response.status_code) + ' ' + response.text)
        raise Exception('login failed')
    return response.json()['Token']


def create_project(name, token):
    url = server + '/API/Project'
    payload = {
        'Name': name,
        'CustomPath': ''
    }
    payload = json.dumps(payload)
    headers = {
        'Authorization': token,
        'Content-Type': 'application/json'
    }
    response = requests.request('POST', url, headers=headers, data=payload)
    if response.status_code != 200:
        print('creating project failed' + str(response.status_code) + ' ' + response.text)
        raise Exception('create project failed')
    return response.json()['Id'], response.json()['AccessToken']


def upload_file(fname, auth_token, project_id):
    file_size = os.path.getsize(fname)
    url = f'{server}/API/Project/{project_id}/Files/UploadMediaFile?fileSize={file_size}'

    payload = {}
    files = [
        ('name', open(fname, 'rb'))
    ]
    headers = {
        'Authorization': auth_token
    }

    response = requests.request('POST', url, headers=headers, data=payload, files=files)
    if response.status_code != 200:
        print('file upload failed' + str(response.status_code) + ' ' + response.text)
        raise Exception('file upload failed')

def transcribe_file(auth_token, project_id, language):
    url = f'{server}/API/Project/Queue/Enqueue?projectId={project_id}&lang={language}&transcriptionProfile=default'
    print(url)
    payload = {}
    files = {}
    headers = {
      'Authorization': auth_token
    }
    response = requests.request('GET', url, headers=headers, data=payload, files=files)
    if response.status_code != 200:
        # something unexpected happened
        print('enqueue failed ' + str(response.status_code) + ' ' + response.text)
        raise Exception('failed to transcribe')

# acquires trsx (xml output of the ASR including transcription with timestamps)
def download_original_trsx(auth_token, project_id):
    url = f'{server}/API/Project/{project_id}/Files/OriginalTrsx'
    payload  = {}
    headers = {
        'Authorization': auth_token,
        'Content-Type': 'application/json'
    }

    response = requests.request('GET', url, headers=headers, data = payload)
    print(response)
    return response.text

def get_subtitles(auth_token, project_id):
    url = f'{server}/API/Project/{project_id}/Export?formatId=srt'

    payload = {}
    headers = {
      'Authorization': auth_token,
      'Content-Type': 'application/json; charset=utf-8'
    }

    response = requests.request('GET', url, headers=headers, data = payload)
    response.encoding = 'utf-8'
    print(response)
    return response.text


# Wait until transcription is complete
def wait_for_trsx(auth_token, project_id):
    print('poll for trsx:')
    url = server + f'/API/Project/{project_id}'

    payload = {}
    headers = {
        'Authorization': auth_token,
        'Content-Type': 'application/json'
    }
    originalTrsxId = None
    for i in range(240): # give up after 2 hours
        response = requests.request('GET', url, headers=headers, data = payload)
        originalTrsxId = response.json()['OriginalTrsxId']
        if originalTrsxId != None:
            print('trsx available - transcription ended')
            return True
        print('trsx not yet available, retrying in 30 s...')
        time.sleep(30)
    print('transcription timed out')
    return False

def save_file(content, name):
    with open(name, 'w', encoding='utf-8') as output_file:
        output_file.write(content)


if (__name__ == '__main__'):
    parser = argparse.ArgumentParser()
    parser.add_argument('recording')
    parser.add_argument('output')
    parser.add_argument('--language', default='cs-CZ')
    parser.add_argument('--subtitles', action='store_true')
    args = parser.parse_args()

    server, email, password = load_credentials()

    print('login...')
    auth_token = login(server, email, password)

    print('creating project...')
    project_id, access_token = create_project('api ' + args.recording, token=auth_token)

    print('uploading file...')
    upload_file(args.recording, auth_token, project_id)

    print('requesting transcription...')
    transcribe_file(auth_token, project_id, args.language)

    print('waiting for trsx...')
    wait_for_trsx(auth_token, project_id)
    
    print('saving...')
    if (args.subtitles):
      subtitles = get_subtitles(auth_token, project_id)
      save_file(subtitles, args.output)
      print('subtitles saved to: ' + args.output)
    else:
      trsx = download_original_trsx(auth_token, project_id)
      save_file(trsx, args.output)
      print('trsx saved to: ' + args.output)
    print('done.')
```
</details>

File can be uploaded through standard REST API as in the example script or via WebSocket. WebSocket upload has low latency and also allows reconnect, although you need to implement it on the client side. Read more about [websocket upload](https://github.com/newtontechnologies/beey-data-exchange-model/blob/master/docs/websocket-upload.md).

C# library
----------

A library implementing connection to the most important endpoints including examples is available here: [beey-dotnet-client](https://github.com/newtontechnologies/beey-dotnet-client)

Complete list of endpoints
--------------------------

The complete list of endpoints is available as a postman collection. To open it, install Postman and import the collection: [Beey.postman_collection.json](https://github.com/newtontechnologies/beey-data-exchange-model/blob/master/Beey.postman_collection.json)
