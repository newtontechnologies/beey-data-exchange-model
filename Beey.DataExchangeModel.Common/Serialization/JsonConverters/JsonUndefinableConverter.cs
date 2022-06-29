using Beey.DataExchangeModel.Tools;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Serialization.JsonConverters
{
    public class JsonUndefinableConverter : JsonConverterFactory
    {
        public JsonUndefinableConverter() : base()
        {

        }
        private static readonly Type s_typeOfIUndefinable = typeof(IUndefinable);

        public override bool CanConvert(Type objectType) => s_typeOfIUndefinable.IsAssignableFrom(objectType);



        private class UTConverter<T> : JsonConverter<Undefinable<T>>
        {
            public override Undefinable<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.Null)
                {
                    var value = JsonSerializer.Deserialize<T>(ref reader, options)!;
                    try
                    {
                        return new Undefinable<T>(value);
                    }
                    catch (Exception ex)
                    {
                        throw new JsonException($"Cannot assign {(object)value ?? "[null]"} to property of type {typeof(T)}", ex);
                    }
                }

                return new Undefinable<T>();
            }

            public override void Write(Utf8JsonWriter writer, Undefinable<T> value, JsonSerializerOptions options)
            {
                var undefinable = (IUndefinable)value;
                if (!undefinable.IsDefined)
                    writer.WriteRawValue("undefined", true);
                else
                    JsonSerializer.Serialize(writer, undefinable.Value, options);
            }
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
