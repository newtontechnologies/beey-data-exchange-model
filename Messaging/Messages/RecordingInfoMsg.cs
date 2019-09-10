using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8618,8603
namespace Beey.DataExchangeModel.Messaging.Messages
{
    public partial class RecordingInfoMsg : Message<RecordingInfoMsg.MessageKind>
    {
        public object Data { get; set; }
        public enum MessageKind
        {
            Started,
            RawFileInfo,
            Duration,
            ApproximateDuration,
            Failed,
        }
    }
}
