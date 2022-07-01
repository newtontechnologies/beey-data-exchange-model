using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Transcriptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging.Subsystems;

public class RecognitionData : SubsystemData<RecognitionData>
{
    [JsonConverter(typeof(JsonNgEventConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public NgEvent NgEvent { get; set; }

    [JsonConverter(typeof(JsonNullableConverter<JsonTimeSpanConverter, TimeSpan>))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeSpan? RecognitionLength { get; set; }

    [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(JsonNullableConverter<JsonTimeSpanConverter, TimeSpan>))]
    public TimeSpan? Transcribed { get; set; }
}
