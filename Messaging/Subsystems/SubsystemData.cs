using Beey.DataExchangeModel.Serialization.JsonConverters;
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public abstract class SubsystemData
    {
        public static JsonSerializerOptions defaultOptions = new JsonSerializerOptions()
            .AddConverters(new JsonStringEnumConverter(), new JsonTimeSpanConverter());
        public virtual JsonData Serialize()
            => new JsonData(JsonSerializer.Serialize<object>(this, defaultOptions));
        public abstract void Initialize(JsonData data);
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
