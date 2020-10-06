using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public class EmptyConfig : SubsystemConfig
    {
        protected override void AddToConfiguration(IConfigurationBuilder builder)
        {
        }
    }
}
