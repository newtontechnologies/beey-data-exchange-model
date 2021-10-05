using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Projects
{
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
    }

    public enum ProjectErrorReason_Transcoding
    {
        Unknown,
    }

    public enum ProjectErrorReason_Transcription
    {
        Unknown,
    }

    public enum ProjectErrorReason
    {
        Unknown,
        NotEnoughCredit,
        ServerShutdown,
    }
}
