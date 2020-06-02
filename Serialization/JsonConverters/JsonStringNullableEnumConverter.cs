using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Serialization.JsonConverters
{
    
    /// <summary>
    /// TODO: Remove when support for nullable enum is native in JsonStringEnumConverter.
    /// </summary>
    [Obsolete]
    public class JsonStringNullableEnumConverter : JsonConverterFactory
    {
        private readonly bool allowIntegerValues;

        public JsonStringNullableEnumConverter() : this(true)
        {

        }
        public JsonStringNullableEnumConverter(bool allowIntegerValues = true)
        {
            this.allowIntegerValues = allowIntegerValues;
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Nullable<>)
                && typeToConvert.GetGenericArguments()[0].IsEnum;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return (JsonConverter)Activator.CreateInstance(typeof(JsonStringNullableEnumConverterInner<>).MakeGenericType(typeToConvert.GetGenericArguments()[0]), (object)allowIntegerValues);
        }

        private class JsonStringNullableEnumConverterInner<T> : JsonConverter<T?>
            where T : struct
        {
            private readonly bool allowIntegerValues;

            public JsonStringNullableEnumConverterInner(bool allowIntegerValues)
            {
                this.allowIntegerValues = allowIntegerValues;
            }
            public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                    return null;
                else if (reader.TokenType == JsonTokenType.String)
                    return Enum.Parse<T>(reader.GetString());
                else if (reader.TokenType == JsonTokenType.Number && allowIntegerValues && Enum.IsDefined(typeof(T), reader.GetInt32()))
                    return (T)Enum.ToObject(typeof(T), reader.GetInt32());
                else
                    throw new ArgumentException("Invalid enum value.");
            }

            public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
            {
                if (value.HasValue)
                    writer.WriteStringValue(value.Value.ToString());
                else
                    writer.WriteNullValue();
            }
        }
    }
}
