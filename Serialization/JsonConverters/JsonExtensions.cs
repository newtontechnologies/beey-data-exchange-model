using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Serialization.JsonConverters
{
    static class JsonExtensions
    {
        public static JsonSerializerOptions AddConverters(this JsonSerializerOptions options, params JsonConverter[] converters)
        {
            foreach (var converter in converters ?? System.Linq.Enumerable.Empty<JsonConverter>())
            {
                options.Converters.Add(converter);
            }
            return options;
        }
        public static JsonSerializerOptions WithConverters(this JsonSerializerOptions options, params JsonConverter[] converters)
        {
            var result = options.Clone();
            foreach (var converter in converters ?? System.Linq.Enumerable.Empty<JsonConverter>())
            {
                result.Converters.Add(converter);
            }
            return result;
        }

        public static JsonSerializerOptions Clone(this JsonSerializerOptions options)
        {
            var result = new JsonSerializerOptions();
            result.AllowTrailingCommas = options.AllowTrailingCommas;
            result.DefaultBufferSize = options.DefaultBufferSize;
            result.DictionaryKeyPolicy = options.DictionaryKeyPolicy;
            result.Encoder = options.Encoder;
            result.IgnoreNullValues = options.IgnoreNullValues;
            result.IgnoreReadOnlyProperties = options.IgnoreReadOnlyProperties;
            result.MaxDepth = options.MaxDepth;
            result.PropertyNameCaseInsensitive = options.PropertyNameCaseInsensitive;
            result.PropertyNamingPolicy = options.PropertyNamingPolicy;
            result.ReadCommentHandling = options.ReadCommentHandling;
            result.WriteIndented = options.WriteIndented;

            foreach (var converter in options.Converters)
            {
                result.Converters.Add(converter);
            }

            return result;
        }

        public static T ToObject<T>(this JsonElement element, JsonSerializerOptions options = null)
        {
            var bufferWriter = new MemoryStream();
            using (var writer = new Utf8JsonWriter(bufferWriter))
            {
                element.WriteTo(writer);
            }

            return JsonSerializer.Deserialize<T>(bufferWriter.ToArray(), options);
        }

        public static T ToObject<T>(this JsonDocument document, JsonSerializerOptions options = null)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            return document.RootElement.ToObject<T>(options);
        }

        public static object ToObject(this JsonElement element, Type returnType, JsonSerializerOptions options = null)
        {
            if (returnType is null)
            {
                throw new ArgumentNullException(nameof(returnType));
            }

            var bufferWriter = new MemoryStream();
            using (var writer = new Utf8JsonWriter(bufferWriter))
            {
                element.WriteTo(writer);
            }

            return JsonSerializer.Deserialize(bufferWriter.ToArray(), returnType, options);
        }

        public static object ToObject(this JsonDocument document, Type returnType, JsonSerializerOptions options = null)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            return document.RootElement.ToObject(returnType, options);
        }
    }
}
