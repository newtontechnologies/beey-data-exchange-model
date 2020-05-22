using Beey.DataExchangeModel.Transcriptions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Serialization.JsonConverters
{
    // TODO: HACK: reimplement
    class JsonNgEventConverter : JsonConverter<NgEvent>
    {
        public override NgEvent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var document = JsonDocument.ParseValue(ref reader);
            try
            {
                return NgEvent.Deserialize(JObject.Parse(document.RootElement.GetRawText()), null);
            }
            catch(Exception ex)
            {
                Serilog.Log.Logger.Fatal(document.RootElement.GetRawText());
                throw;
            }
        }

        public override void Write(Utf8JsonWriter writer, NgEvent value, JsonSerializerOptions options)
        {
            var document = JsonDocument.Parse(value.Serialize().ToString());
            document.WriteTo(writer);
        }
    }
}
