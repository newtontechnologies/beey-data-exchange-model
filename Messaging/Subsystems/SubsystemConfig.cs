using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public abstract class SubsystemConfig
    { 
        public IConfiguration ToConfiguration()
        {
            var builder = new ConfigurationBuilder();
            this.AddToConfiguration(builder);
            return builder.Build();
        }

        // TODO: can be implemented recursively using reflection, but would be slower
        protected abstract void AddToConfiguration(IConfigurationBuilder builder);        
    }

    public abstract class SubsystemConfig<T> : SubsystemConfig
        where T : SubsystemConfig
    {
        public static T From(MessageNew startedMessage)
        {
            var config = ExtractConfig(startedMessage);
            var result = config.Get<T>();
            return result;
        }
        private static IConfiguration ExtractConfig(MessageNew startedMessage)
        {
            return startedMessage is StartedMessage m
                ? m.Config
                : throw new ArgumentException("Bad message type.", nameof(startedMessage));
        }
    }
}