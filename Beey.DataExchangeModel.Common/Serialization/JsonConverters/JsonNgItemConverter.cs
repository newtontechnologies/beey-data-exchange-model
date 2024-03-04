using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Beey.DataExchangeModel.Common.Transcriptions;

namespace Beey.DataExchangeModel.Common.Serialization.JsonConverters;

public class JsonNgItemConverter : JsonConverter<NgItem>
{
    public override NgItem? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var document = JsonNode.Parse(
            ref reader,
            new JsonNodeOptions { PropertyNameCaseInsensitive = options.PropertyNameCaseInsensitive })?.AsObject();
        return NgItem.Deserialize(document);
    }

    public override void Write(Utf8JsonWriter writer, NgItem value, JsonSerializerOptions options)
    {
        var document = JsonDocument.Parse(value.Serialize().ToString());
        document.WriteTo(writer);
    }
}
