using Beey.DataExchangeModel.Transcriptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Messaging.Messages
{
    public partial class ASRMsg : Message<ASRMsg.MessageKind>
    {
        public NgEvent Event { get; set; }
        public enum MessageKind
        {
            Phrase,
            Speaker,
            SpeakerRecovery,
        }
    }
}
