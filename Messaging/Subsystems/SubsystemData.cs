using Beey.DataExchangeModel.Serialization.JsonConverters;
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public abstract class SubsystemData
    {
        protected static JsonSerializerOptions CreateDefaultOptions()
            => new JsonSerializerOptions()
                .AddConverters(new JsonStringEnumConverter(), new JsonTimeSpanConverter(), new JsonUnknownObjectConverter());


        public virtual JsonData Serialize()
            => new JsonData(JsonSerializer.Serialize<object>(this, CreateDefaultOptions()));
    }

    public abstract class SubsystemData<T> : SubsystemData
        where T : SubsystemData<T>, new()
    {
        public virtual T? Deserialize(JsonData data)
            => JsonSerializer.Deserialize<T>(data.Raw, CreateDefaultOptions());

        public static T? From(Message progressMessage)
        {
            var data = ExtractData(progressMessage);
            var result = new T();
            return result.Deserialize(data);
        }

        private static JsonData ExtractData(Message progressMessage)
        {
            return progressMessage is ProgressMessage m
                ? m.Data
                : throw new ArgumentException("Bad message type.", nameof(progressMessage));
        }
    }
}
