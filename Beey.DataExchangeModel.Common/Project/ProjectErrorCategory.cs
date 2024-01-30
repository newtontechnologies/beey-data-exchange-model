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
    Unauthorised,
}

public enum ProjectErrorReason_General
{
    Unknown,
    NotEnoughCredit,
    ServerShutdown,
}

// https://ffmpeg.org//doxygen/trunk/error_8h_source.html
// codes are reversed, converted into their ascii counterparts and then to decimal
// 
// TODO move away
public enum FFmpegExitCodes
{
    DecoderNotFound = -1128613112,
    DemuxerNotFound = -1296385272,
    EncoderNotFound = -1129203192,
    MuxerNotFound = -1481985528,
    InvalidDataFound = -1094995529,
}
