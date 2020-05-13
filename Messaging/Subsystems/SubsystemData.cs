using System;
using System.Reflection;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public abstract class SubsystemData
    {
        public static T From<T>(MessageNew progressMessage) where T : SubsystemData, new()
        {
            var config = ExtractData(progressMessage);
            var result = new T();
            result.Initialize(config);
            return result;
        }

        public virtual JsonData Serialize(JsonSerializerOptions options = null)
            => new JsonData(JsonSerializer.Serialize(this, typeof(object), options));
        public abstract void Initialize(JsonData data);

        private static JsonData ExtractData(MessageNew progressMessage)
        {
            return progressMessage is ProgressMessage m
                ? m.Data
                : throw new ArgumentException("Bad message type.", nameof(progressMessage));
        }
    }
}
