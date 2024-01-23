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
    Unknown,
    NoFiles,
}

public enum ProjectErrorReason_Transcoding
{
    UnknownLength,
    NoAudio,
    NoBitRate,
    NoStream,
    NoAudioProduced,
    NoVideoProduced,
    TranscodeStuck,
}

public enum ProjectErrorReason_Transcription
{
    EmptyTrsxNotSaved,
    InvalidTimestampInterval,
    MissingMedia,
    InvalidLanguage,
}

public enum ProjectErrorReason_General
{
    Unknown,
    NotEnoughCredit,
    ServerShutdown,
}
