using Beey.DataExchangeModel.Serialization.JsonConverters;
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging.Subsystems;

public abstract class SubsystemData
{
    protected static JsonSerializerOptions CreateDefaultOptions() => new JsonSerializerOptions()
    {
        Converters = { new JsonStringEnumConverter(), new JsonTimeSpanConverter(), new JsonUnknownObjectConverter() }
    };

    public virtual JsonNode Serialize()
        => JsonSerializer.SerializeToNode<object>(this, CreateDefaultOptions())!;

    public static implicit operator JsonNode(SubsystemData d) => d.Serialize();
}

public abstract class SubsystemData<T> : SubsystemData
    where T : SubsystemData<T>, new()
{
    public static T? From(ProgressMessage progressMessage)
    {
        var data = progressMessage.Data;
        return JsonSerializer.Deserialize<T>(data, CreateDefaultOptions());
    }
}
