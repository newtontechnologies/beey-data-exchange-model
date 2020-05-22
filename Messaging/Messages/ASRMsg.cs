using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Transcriptions;
using System.Text.Json.Serialization;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Messaging.Messages
{
    public partial class ASRMsg : Message<ASRMsg.MessageKind>
    {
        [JsonConverter(typeof(JsonNgEventConverter))]
        public NgEvent Event { get; set; }
        public enum MessageKind
        {
            Phrase,
            Speaker,
            SpeakerRecovery,
        }
    }
}
