using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Projects
{
    public enum ProjectErrorCategory
    {
        None,
        Upload,
        Transcoding,
        Transcription,
        Various
    }

    public enum ProjectErrorReason_Upload
    {
        NotSpecified,
    }

    public enum ProjectErrorReason_Transcoding
    {
        NotSpecified,
    }

    public enum ProjectErrorReason_Transcription
    {
        NotSpecified,
    }

    public enum ProjectErrorReason_Various
    {
        Unknown,
        NotEnoughCredit,
        ServerShutdown,
    }
}
