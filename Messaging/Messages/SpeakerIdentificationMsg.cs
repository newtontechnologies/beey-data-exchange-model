using Beey.DataExchangeModel.Transcriptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranscriptionCore;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Messaging.Messages
{
    public partial class SpeakerIdentificationMsg : Message<SpeakerIdentificationMsg.MessageKind>
    {
        public string XMLSpeaker { get; set; }
        public int ASRMsgId { get; set; }
        public enum MessageKind
        {
            Speaker,
            Unidentified,
            Started,
            Completed,
            Failed,
        }
    }
}
