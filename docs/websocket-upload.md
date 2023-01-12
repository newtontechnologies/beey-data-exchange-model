# WebSocket upload
Connect to URL `{server}/ws/Upload?id={ProjectId}&saveMedia={bool}`. If uploading stream, set `saveMedia` to false.

As a first message server sends an object FileStateInfo
```
{
    "IsInitialized" : bool, 
    "FileName" : string,
    "BufferSize" : int,
    "TotalFileSize" : long/null,
    "CurrentFileOffset" : long
}
```

* Buffer of size `BufferSize` bytes is used during upload.
* If upload was already started but interrupted, `IsInitialized` is true and `CurrentFileOffset` is a number of bytes already uploaded.
* Otherwise `IsInitialized` is false.

As a response, the same object is expected with filled `FileName`, `CurrentFileOffset` and `TotalFileSize`. Either `CurrentFileOffset` must remain the same to continue upload or it must be set to 0 when upload should be restarted.

Format of the binary data messages must be as follows: `offset` `count` `data`, where:
* `offset` is long,
* `count` is short (Int16),
* `data` is `count` of binary data.

After the "handshake":
1. data can start to flow to the WebSocket; buffer size has to be lesser or equal than the agreed upon `BufferSize`.
2. every X seconds backend sends message with number of obtained bytes
   * first heartbeat also marks the moment when the upload is initialized in backend

## Errors

### Before handshake

* Id is not provided:
    * 1008 - `Project id not set`
* Project does not exist / user cannot access project:
    * 1001 - `Project does not exist or user does not have access to it`
* Upload already marked as finished:
    * 1008 - `Cannot upload, already completed`

### After handshake

* Attempt to restart upload (CurrentFileOffset == 0):
    * 1008 - `Upload cannot be restarted, destroy chain and try again`
* Wrong number of written bytes (CurrentFileOffset differs):
    * 1008 - `To restore upload, transfer has to be continuous`
* Attempt to upload after timeout:
    * 1008 - `Upload cannot be restored, restore timed out`

### During upload

* Timeout - no data obtained by backend:
    * 1008 - `Connection timeouted after {timeout}s`
* Data larger than message buffer:
    * 1009 - `Message does not fit into {buffer size}B buffer`
* Wrong offset, i.e. current data does not start where previous data ended:
    * 1008 - `Transfer has to be continuous, server has {server data offset}B of data, not {new data offset}B`
* Wrong lenght of data message:
    1007 - `Invalid value of data size`
* Attempt to upload to old websocket (i.e. upload to another, newly opened WS is already in progress):
    * 1008 - `Upload reconnected during receiving data from last websocket`
* Attempt to upload when upload was already mark as finished for some reason (completed, error, timeout etc.)
    * 1001 - `Attempt to write to completed upload for project {ProjectId}. (on active upload? {active})`
* Unknown error:
    1011 - `Error: '{exception.Message}'`

