using System;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging
{
    public class JsonData
    {
        private readonly Lazy<JsonElement> jsonElement; 

        public string Raw { get; }
        public JsonElement JsonElement => jsonElement.Value;

        public JsonData(string raw, JsonElement? jsonElement = null)
        {
            Raw = raw;
            this.jsonElement = jsonElement.HasValue
                ? new Lazy<JsonElement>(jsonElement.Value)
                : new Lazy<JsonElement>(() => JsonSerializer.Deserialize<JsonElement>(raw));
        }
    }
}
