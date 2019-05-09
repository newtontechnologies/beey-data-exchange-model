using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeyApi.Messaging.Messages
{
    public partial class RecordingConversionMsg : Message<RecordingConversionMsg.MessageKind>
    {
        public enum MessageKind
        {
            Started,
            Completed,
            Failed,
        }
    }
}
