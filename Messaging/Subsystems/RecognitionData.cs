using Beey.DataExchangeModel.Messaging.Messages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class RecognitionData : SubsystemData<RecognitionData>
    {
        public ASRMsg AsrMsg { get; set; }
        public TimeSpan? Transcribed { get; set; }
        public override void Initialize(JsonData data)
        {
            if (data.JsonElement.TryGetProperty(nameof(AsrMsg), out var asrMsgProp))
                AsrMsg = JsonSerializer.Deserialize<ASRMsg>(asrMsgProp.GetRawText());

            if (data.JsonElement.TryGetProperty(nameof(Transcribed), out var transcribedProp))
                Transcribed = JsonSerializer.Deserialize<TimeSpan>(transcribedProp.GetRawText());
        }
    }
}
