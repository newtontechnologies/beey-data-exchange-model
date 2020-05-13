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
        public static T From<T>(MessageNew startedMessage) where T : SubsystemConfig
        {
            var config = ExtractConfig(startedMessage);
            var result = config.Get<T>();
            return result;
        }

        public IConfiguration ToConfiguration()
        {
            var builder = new ConfigurationBuilder();
            this.AddToConfiguration(builder);
            return builder.Build();
        }

        // TODO: can be implemented recursively using reflection, but would be slower
        protected abstract void AddToConfiguration(IConfigurationBuilder builder);

        private static IConfiguration ExtractConfig(MessageNew startedMessage)
        {
            return startedMessage is StartedMessage m
                ? m.Config
                : throw new ArgumentException("Bad message type.", nameof(startedMessage));
        }
    }
}