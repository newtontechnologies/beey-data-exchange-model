namespace Beey.DataExchangeModel.Projects;

public enum ProjectErrorCategory
{
    General,
    Upload,
    Transcoding,
    Transcription,
}

public enum ProjectErrorReason_Upload
{
    MissingFile,
    TeamStorageQuotaExceeded,
}

public enum ProjectErrorReason_Transcoding
{
    UnknownDuration,
    MissingAudio,
    MissingBitRateInformation,
    NoAudioProduced,
    NoVideoProduced,
    TranscodingStuck,
    UnsupportedMedia,
    CorruptedMedia,
}

public enum ProjectErrorReason_Transcription
{
    NoDataToCreateTrsx,
    InvalidTimestampInterval,
    MissingMedia,
    InvalidLanguage,
    InvalidState,
    InsufficientCapacity,
    NanogridUnauthorized,
    NanogridUnknown,
}

public enum ProjectErrorReason_General
{
    Unknown,
    NotEnoughCredit,
    ServerShutdown,
}
