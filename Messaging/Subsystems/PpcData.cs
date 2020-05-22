﻿using Backend.Serialization.Json;
using Beey.DataExchangeModel.Messaging.Messages;
using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Transcriptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class PpcData : SubsystemData<PpcData>
    {
        private static readonly JsonNgEventConverter eventConverter = new JsonNgEventConverter();
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions().WithConverters(eventConverter);

        public enum DataKind { Phrase, Speaker, SpeakerRecovery }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DataKind Kind { get; set; }

        [JsonConverter(typeof(JsonNgEventConverter))]
        public NgEvent Event { get; set; }

        public override JsonData Serialize(JsonSerializerOptions options = null)
            => new JsonData(JsonSerializer.Serialize<PpcData>(this, options));
        public override void Initialize(JsonData data, JsonSerializerOptions options = null)
        {
            Kind = Enum.Parse<DataKind>(data.JsonElement.GetProperty(nameof(Kind)).GetString());
            Event = NgEvent.Deserialize(Newtonsoft.Json.Linq.JObject.Parse(data.JsonElement.GetProperty(nameof(Event)).GetRawText()), null);
        }
    }
}
