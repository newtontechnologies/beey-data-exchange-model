using Beey.DataExchangeModel.Messaging.Messages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class PpcData : SubsystemData
    {
        public ASRMsg AsrMsg { get; set; }
        public override void Initialize(JsonData data)
        {
            AsrMsg = JsonSerializer.Deserialize<ASRMsg>(data.JsonElement.GetProperty(nameof(AsrMsg)).GetRawText());
        }
    }
}
