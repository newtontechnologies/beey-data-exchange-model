using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class EmptyData : SubsystemData
    {
        public override void Initialize(JsonData data, JsonSerializerOptions options = null)
        {
        }
    }
}
