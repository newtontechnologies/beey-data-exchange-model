using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Transcriptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class RecognitionData : SubsystemData<RecognitionData>
    {
        [JsonConverter(typeof(JsonNgEventConverter))]
        public NgEvent NgEvent { get; set; }

        [JsonConverter(typeof(JsonNullableConverter<JsonTimeSpanConverter, TimeSpan>))]
        public TimeSpan? RecognitionLength { get; set; }

        [JsonConverter(typeof(JsonNullableConverter<JsonTimeSpanConverter, TimeSpan>))]
        public TimeSpan? Transcribed { get; internal set; }
    }
}
