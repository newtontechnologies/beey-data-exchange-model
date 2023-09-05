# Frequently asked questions

## What are the differences between CurrentTrsx and OriginalTrsx?

OriginalTranscription is always created if the transcription is successful.
It does not change when someone edits the document in Beey.

CurrentTranscription updates when anyone edits the document in Beey, but it is available only after someone edits
the document in editor (or uploads CurrentTrsx via API)

There are two major differences between OriginalTranscription and CurrentTranscription:
OriginalTranscription contains additional information about non-speech events – phrases containing string
`[n::` or `[h::`. Moreover, unidentified speakers are saved in different format.
This is unfortunate and it may be changed in next API version.
However, until then, if you need to parse unknown speakers from OriginalTranscription,
you need to match the surname with this regex: /^S[0-9]{4,5}$/ (S and four or five digits)
to detect that it is an unknown speaker and convert it to any format that you want.

## Why do I get error 409? What is AccessToken?

Whenever you make any change of a project - updating trsx, changing tags, sharing, changing name, etc,
You need to prove that you had up to date version of the project before you made that change. Otherwise
the change will be rejected to prevent conflicts.

Every operation that changes project returns project in body. In the response, you can find an integer
AccessToken. You can think of AccessToken as the project version. In the next request, you must send
the last AccessToken that you received after your last change of the project.

If you still get error 409, there was probably some unexpected change of the project. Fetch Project to
to update the project with the changes made by someone else. Then send your request again with the correct
AccessToken.

Do not confuse AccessToken and AuthToken. AuthToken is a string that proves that you are
authorized to make the change. AccessToken is an integer that proves that you have project up to date.

## Media file was uploaded but the transcription is loading and there is no error

Check that you called the Enqueue endpoint, which triggers the transcription, see the example scripts.
