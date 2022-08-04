using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Beey.DataExchangeModel.Messaging.Subsystems;
using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Transcriptions;

namespace Beey.DataExchangeModel.Common.Messaging;
public class SppData : SubsystemData<SppData>
{
    [JsonConverter(typeof(JsonNgEventConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public NgPhraseEvent? RecognitionData { get; set; } = null;
    [JsonConverter(typeof(JsonNgEventConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public NgSpeakerEvent? DiarizationData { get; set; } = null;
}

