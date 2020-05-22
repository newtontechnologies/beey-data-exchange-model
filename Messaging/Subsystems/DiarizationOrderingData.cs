using Beey.DataExchangeModel.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class DiarizationOrderingData : SubsystemData<DiarizationOrderingData>
    {
        public ASRMsg AsrMsg { get; set; }
        public override void Initialize(JsonData data, JsonSerializerOptions options = null)
        {
            AsrMsg = JsonSerializer.Deserialize<ASRMsg>(data.JsonElement.GetProperty(nameof(AsrMsg)).GetRawText(), options);
        }
    }
}
