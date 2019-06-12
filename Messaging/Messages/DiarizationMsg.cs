using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Messaging.Messages
{
    public partial class DiarizationMsg : Message<DiarizationMsg.MessageKind>
    {
        [Flags]
        public enum MessageKind
        {
            Started,
            Completed,
            Failed,
            Interrupted,
            IsTerminated = Completed | Failed | Interrupted,
        }
    }
}
