using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Projects
{
    public enum ProjectErrorCause
    {
        None,
        Precondition,
        Upload,
        Transcoding,
        Transcription,
        Other
    }

    public enum ProjectErrorCauseDetail_Precondition
    {
        Unknown = 0,
        NotEnoughCredit = 1,
    }

    public enum ProjectErrorCauseDetail_Upload
    {
        Unknown = 0,
    }

    public enum ProjectErrorCauseDetail_Transcoding
    {
        Unknown = 0,        
    }

    public enum ProjectErrorCauseDetail_Transcription
    {
        Unknown = 0,
    }

    public enum ProjectErrorCauseDetail_Other
    {
        Unknown = 0,
        ServerShutdown = 1,
    }
}
