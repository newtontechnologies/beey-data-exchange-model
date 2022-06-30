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

        public static T? From(ProgressMessage progressMessage)
        {
            var data = progressMessage.Data;
            var result = new T();
            return result.Deserialize(data);
        }
    }
}
