using Backend.Serialization.Json;
using Beey.DataExchangeModel.Messaging.Messages;
using Beey.DataExchangeModel.Transcriptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class PpcData : SubsystemData
    {
        private static readonly SimpleJsonConverter<NgEvent> eventConverter 
            = new SimpleJsonConverter<NgEvent>(serialize: e => e.Serialize().ToString());
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions().WithConverters(eventConverter);
        public enum DataKind { Phrase, Speaker, SpeakerRecovery }
        public DataKind Kind { get; set; }
        public NgEvent Event { get; set; }

        public override JsonData Serialize(JsonSerializerOptions options = null)
            => new JsonData(JsonSerializer.Serialize<PpcData>(this, options?.WithConverters(eventConverter) ?? options));
        public override void Initialize(JsonData data)
        {
            Kind = Enum.Parse<DataKind>(data.JsonElement.GetProperty(nameof(Kind)).GetRawText());
            Event = NgEvent.Deserialize(Newtonsoft.Json.Linq.JObject.Parse(data.JsonElement.GetProperty(nameof(Event)).GetRawText()), null);
        }
    }
}
