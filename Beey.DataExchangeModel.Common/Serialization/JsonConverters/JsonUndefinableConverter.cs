﻿using Beey.DataExchangeModel.Tools;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Serialization.JsonConverters;

public class JsonUndefinableConverter : JsonConverterFactory
{
    public JsonUndefinableConverter() : base()
    {

    }
    private static readonly Type s_typeOfUndefinable = typeof(Undefinable<>);

    public override bool CanConvert(Type typeToConvert) 
        => typeToConvert.IsGenericType 
        && typeToConvert.GetGenericTypeDefinition() == s_typeOfUndefinable;

    private class UTConverter<T> : JsonConverter<Undefinable<T>>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(Undefinable<T>);
        }

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
            if (!value.IsDefined)
                throw new JsonException("Cannot serialize undefined value. Please use JsonIgnoreAttribute to ignore default (undefined) value.");
            else
                JsonSerializer.Serialize(writer, value.Value, options);
        }
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert.GetGenericTypeDefinition() == typeof(Undefinable<>))
        {
            var args = typeToConvert.GetGenericArguments();
            var type = typeof(UTConverter<>).MakeGenericType(args[0]);
            var conv =  (JsonConverter)Activator.CreateInstance(type)!;
            return conv;
        }
        return null;
    }
}
