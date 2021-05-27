using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Projects
{
    public enum ProjectProcessingState
    {
        None = 0,
        Processing = 1,
        Canceled = 2,
        Completed = 3,
        Failed = 4
    }
}
