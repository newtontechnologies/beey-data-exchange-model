using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Tools;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Messaging;

//subsystem must be always second in serialized data..
public abstract record Message(int Id, ImmutableArray<int> Index, int? ProjectId, [property: JsonPropertyOrder(int.MinValue + 1)] string Subsystem, DateTimeOffset Sent)
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonPropertyOrder(int.MinValue)]//always must be second for deserialization to work
    public abstract MessageType Type { get; }

    public static JsonSerializerOptions CreateDefaultOptions()
    {
        var opts = new JsonSerializerOptions();
        opts.Converters.Add(new MessageJsonConverterWithTypeDiscriminator());
        opts.Converters.Add(new JsonStringEnumConverter());
        opts.Converters.Add(new JsonNgEventConverter());
        return opts;

    }

    public static ArraySegment<byte> Serialize(Message message)
    {
        var json = JsonSerializer.Serialize(message, CreateDefaultOptions());
        var bytes = Encoding.UTF8.GetBytes(json);
        return new ArraySegment<byte>(bytes);
    }
}
