using Beey.DataExchangeModel.Messaging.Messages2;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Messaging.Messages
{
    public partial class DiarizationMsg : Message<DiarizationMsgKind>
    {
        [Flags]
        public enum MessageKind
        {
            Started = 1,
            Completed = 2,
            Failed = 4,
            Interrupted = 8,
            IsTerminated = Completed | Failed | Interrupted,
        }
    }
    
}
