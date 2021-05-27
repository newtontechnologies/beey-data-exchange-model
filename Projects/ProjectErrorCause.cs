using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Projects
{
    public enum ProjectErrorCause
    {
        None = 0,
        Precondition = 1,
        Upload = 2,
        Transcoding = 3,
        Transcription = 4,
        Unknown = 5
    }

    public enum ProjectErrorCauseDetail_Precondition
    {
        None = 0,
        NotEnoughCredit = 1,
    }
    public enum ProjectErrorCauseDetail_Transcoding
    {
        None = 0,
        
    }
}
