using Beey.DataExchangeModel.Messaging.Messages;
using Beey.DataExchangeModel.Serialization.JsonConverters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class RecognitionData : SubsystemData<RecognitionData>
    {
        public ASRMsg AsrMsg { get; set; }

        [JsonConverter(typeof(JsonNullableConverter<JsonTimeSpanConverter, TimeSpan>))]
        public TimeSpan? RecognitionLength { get; set; }
        [JsonConverter(typeof(JsonNullableConverter<JsonTimeSpanConverter, TimeSpan>))]
        public TimeSpan? Transcribed { get; internal set; }

        public override void Initialize(JsonData data)
        {
            if (data.JsonElement.TryGetProperty(nameof(AsrMsg), out var asrMsgProp)
                && asrMsgProp.ValueKind != JsonValueKind.Null)
            {
                AsrMsg = JsonSerializer.Deserialize<ASRMsg>(asrMsgProp.GetRawText(), DefaultOptions);
            }

            if (data.JsonElement.TryGetProperty(nameof(RecognitionLength), out var recognitionLengthProp)
                && recognitionLengthProp.ValueKind != JsonValueKind.Null)
            {
                RecognitionLength = TimeSpan.Parse(recognitionLengthProp.GetString());
            }

            if (data.JsonElement.TryGetProperty(nameof(Transcribed), out var transcribedProp)
                && transcribedProp.ValueKind != JsonValueKind.Null)
            {
                Transcribed = TimeSpan.Parse(transcribedProp.GetString());
            }
        }
    }
}
