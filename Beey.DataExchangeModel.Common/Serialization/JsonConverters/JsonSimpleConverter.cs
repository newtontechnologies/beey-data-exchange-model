using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Serialization.JsonConverters;

public class JsonSimpleConverter<T> : JsonConverter<T>
{
    public delegate T Deserialize(ref Utf8JsonReader reader, JsonSerializerOptions options);
    public delegate void Serialize(Utf8JsonWriter writer, T value, JsonSerializerOptions options);

    private readonly Func<T, string>? serializeSimple;
    private readonly Serialize? serialize;
    private readonly Func<string, T>? deserializeSimple;
    private readonly Deserialize? deserialize;

    /// <summary>
    /// Base constructor. Simple variants are preferred if both variants are set.
    /// </summary>
    /// <param name="serialize"></param>
    /// <param name="serializeSimple"></param>
    /// <param name="deserialize"></param>
    /// <param name="deserializeSimple"></param>
    private JsonSimpleConverter(Serialize? serialize, Func<T, string>? serializeSimple,
        Deserialize? deserialize, Func<string, T>? deserializeSimple)
    {
        this.serialize = serialize;
        this.serializeSimple = serializeSimple;
        this.deserialize = deserialize;
        this.deserializeSimple = deserializeSimple;

        if (serialize == null && serializeSimple == null)
            serialize = DefaultSerialize;

        if (deserialize == null && deserializeSimple == null)
            deserialize = DefaultDeserialize;
    }

    #region constructors
    public JsonSimpleConverter(Serialize serialize)
        : this(serialize, null, null, null)
    { }
    public JsonSimpleConverter(Func<T, string> serialize)
        : this(null, serialize, null, null)
    { }
    public JsonSimpleConverter(Deserialize deserialize)
        : this(null, null, deserialize, null)
    { }
    public JsonSimpleConverter(Func<string, T> deserialize)
        : this(null, null, null, deserialize)
    { }
    public JsonSimpleConverter(Serialize serialize, Deserialize deserialize)
        : this(serialize, null, deserialize, null)
    { }
    public JsonSimpleConverter(Func<T, string> serialize, Func<string, T> deserialize)
        : this(null, serialize, null, deserialize)
    { }
    #endregion constructors

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return deserializeSimple != null
            ? deserializeSimple(reader.GetString())
            : deserialize(ref reader, options);
    }
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (serializeSimple != null)
            writer.WriteStringValue(serializeSimple(value));
        else
            serialize(writer, value, options);
    }

    private static void DefaultSerialize(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        => JsonSerializer.Serialize<T>(writer, value, options);
    private static T? DefaultDeserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        => JsonSerializer.Deserialize<T>(ref reader);
}
