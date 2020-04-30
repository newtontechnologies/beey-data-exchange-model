using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class WsSendConfig : SubsystemConfig
    {
        protected override void AddToConfiguration(IConfigurationBuilder builder)
        {
            throw new NotImplementedException();
        }
    }

    class WsSendData : SubsystemData
    {
        public override void Initialize(JsonData data)
        {
            throw new NotImplementedException();
        }
    }
}
