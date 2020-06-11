using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Serialization.JsonConverters
{
    class JsonNullableConverter<TConverter, TType> : JsonConverter<TType?>
        where TConverter : JsonConverter<TType>, new()
        where TType : struct
    {
        private static TConverter original = new TConverter();
        public override TType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                reader.Read();
                return null;
            }
            else
                return original.Read(ref reader, typeof(TType), options);
        }

        public override void Write(Utf8JsonWriter writer, TType? value, JsonSerializerOptions options)
        {
            if (value == null)
                writer.WriteNullValue();
            else
                original.Write(writer, value.Value, options);
        }
    }
}
