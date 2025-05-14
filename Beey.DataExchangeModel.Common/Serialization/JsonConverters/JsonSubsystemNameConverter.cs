using System.Text.Json;
using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Messaging.Subsystems;

namespace Beey.DataExchangeModel.Serialization.JsonConverters;

public class JsonSubsystemNameConverter : JsonConverter<SubsystemName>
{
    public override SubsystemName Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.GetString() is { } s ? SubsystemName.Get(s) : default;

    public override void Write(Utf8JsonWriter writer, SubsystemName value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString());
}
