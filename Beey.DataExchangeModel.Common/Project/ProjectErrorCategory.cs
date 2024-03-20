using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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