using Beey.DataExchangeModel.Transcriptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Serialization.JsonConverters;

class JsonNgEventConverter : JsonConverter<NgEvent>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeof(NgEvent).IsAssignableFrom(typeToConvert);
    }
    public override NgEvent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var document = (JsonObject)JsonNode.Parse(ref reader, new JsonNodeOptions { PropertyNameCaseInsensitive = options.PropertyNameCaseInsensitive })!;
        return NgEvent.Deserialize(document, null);
    }

    public override void Write(Utf8JsonWriter writer, NgEvent value, JsonSerializerOptions options)
    {
        var document = JsonDocument.Parse(value.Serialize().ToString());
        document.WriteTo(writer);
    }
}
