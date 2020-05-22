using System;
using System.Reflection;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public abstract class SubsystemData
    {
        public virtual JsonData Serialize(JsonSerializerOptions options = null)
            => new JsonData(JsonSerializer.Serialize<object>(this, options));
        public abstract void Initialize(JsonData data, JsonSerializerOptions options = null);
    }

    public abstract class SubsystemData<T> : SubsystemData
        where T : SubsystemData, new()
    {
        public static T From(MessageNew progressMessage)
        {
            var data = ExtractData(progressMessage);
            var result = new T();
            result.Initialize(data);
            return result;
        }


        private static JsonData ExtractData(MessageNew progressMessage)
        {
            return progressMessage is ProgressMessage m
                ? m.Data
                : throw new ArgumentException("Bad message type.", nameof(progressMessage));
        }
    }
}
