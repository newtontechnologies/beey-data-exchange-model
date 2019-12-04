using Beey.DataExchangeModel.Messaging.Messages2;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Messaging.Messages
{
    public partial class AudioExtractionMsg : Message<AudioExtractionMsgKind>
    {
        public enum MessageKind
        {
            Started,
            Completed,
            Failed,
        }
    }


}
