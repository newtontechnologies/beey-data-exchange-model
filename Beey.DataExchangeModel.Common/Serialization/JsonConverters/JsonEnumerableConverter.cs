using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Common.Serialization.JsonConverters;

public class JsonEnumerableConverter<TItem, TConverter> : JsonConverter<IEnumerable<TItem?>>
    where TConverter : JsonConverter<TItem>, new()
{
    private static readonly Type _itemType = typeof(TItem);
    private readonly TConverter _itemConverter = new();
    public override IEnumerable<TItem?>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null
            || reader.TokenType == JsonTokenType.None)
            return null;

        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException($"Unexpected json token {reader.TokenType}.");

        List<TItem?> result = new();

        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            var item = _itemConverter.Read(ref reader, _itemType, options);
            result.Add(item);
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, IEnumerable<TItem?> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (var item in value)
        {
            if (item is null)
                writer.WriteNullValue();
            else
                _itemConverter.Write(writer, item, options);
        }

        writer.WriteEndArray();
    }
}
