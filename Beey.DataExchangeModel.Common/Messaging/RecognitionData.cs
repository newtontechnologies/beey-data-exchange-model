﻿using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Transcriptions;
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

    [JsonConverter(typeof(JsonNgEventConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public NgSpeakerEvent? IntegratedDiarizationData { get; set; }
    
}
