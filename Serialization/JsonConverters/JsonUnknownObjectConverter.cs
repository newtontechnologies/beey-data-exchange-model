using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Serialization.JsonConverters
{
    public class JsonUnknownObjectConverter : JsonConverter<object>
    {
        private static readonly Type typeOfObject = typeof(object);
        private static readonly Type typeOfExpandoObject = typeof(ExpandoObject);

        private JsonSerializerOptions recursiveOptions;

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeOfObject || typeToConvert == typeOfExpandoObject;
        }

        public override object? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
        {
            while (true)
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.False:
                    case JsonTokenType.True:
                        return reader.GetBoolean();
                    case JsonTokenType.Number:
                        if (reader.TryGetInt32(out var i)) { return i; }
                        else if (reader.TryGetInt64(out var l)) { return l; }
                        else if (reader.TryGetDouble(out var d)) { return d; }
                        else if (reader.TryGetDecimal(out var dec)) { return dec; }
                        else // return number as string
                        {
                            return JsonSerializer.Deserialize<JsonElement>(ref reader).GetRawText();
                        }
                    case JsonTokenType.String:
                        return reader.GetString();
                    case JsonTokenType.StartArray:
                        var array = new List<object>();
                        reader.Read();
                        while (reader.TokenType != JsonTokenType.EndArray)
                        {
                            array.Add(Read(ref reader, _, options));
                            reader.Read();
                        }
                        return array.ToArray();
                    case JsonTokenType.StartObject:
                        reader.Read();
                        var res = new ExpandoObject();
                        while (reader.TokenType != JsonTokenType.EndObject)
                        {
                            string key = reader.GetString();
                            reader.Read();
                            res.TryAdd(key, Read(ref reader, _, options));
                            reader.Read();
                        }
                        return res;
                    case JsonTokenType.Null:
                        return null;
                    case JsonTokenType.Comment:
                    case JsonTokenType.None:
                        reader.Read();
                        continue;
                    default:
                        throw new JsonException($"Invalid JSON. Unexpected token '{reader.TokenType}'.");
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (options != null && recursiveOptions == null)
            {
                // handle stack overflow when serializing ExpandoObject
                recursiveOptions = options.Clone();
                recursiveOptions.Converters.Remove(this);
            }
            JsonSerializer.Serialize(writer, value, recursiveOptions);
        }
    }
}
