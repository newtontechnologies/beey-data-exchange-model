﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class MessageCacheConfig : SubsystemConfig
    {
        protected override void AddToConfiguration(IConfigurationBuilder builder)
        {
            throw new NotImplementedException();
        }
    }

    class MessageCacheData : SubsystemData
    {
        public override void Initialize(JsonData data)
        {
            throw new NotImplementedException();
        }
    }
}
