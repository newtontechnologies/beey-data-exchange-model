using Beey.DataExchangeModel.Serialization.JsonConverters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class MediaIdentificationData : SubsystemData<MediaIdentificationData>
    {
        public enum DataKind
        {
            RawFileInfo,
            Duration,
            ApproximateDuration,
            DurationlessStream,
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DataKind Kind { get; set; }
        public object Data { get; set; }

        public override JsonData Serialize(JsonSerializerOptions options = null)
        { 
            // TODO: refactor!
            var converters = new JsonConverter[] {
                new JsonSimpleConverter<JObject>(serialize: (w, jo, o) =>
                {
                    JsonSerializer.Deserialize<JsonElement>(jo.ToString()).WriteTo(w);
                }),
                    new JsonTimeSpanConverter()
            };

            return new JsonData(
                JsonSerializer.Serialize(this, options?.AddConverters(converters) ?? new JsonSerializerOptions().AddConverters(converters))
                );
        }
        public override void Initialize(JsonData data)
        {
            Kind = Enum.Parse<DataKind>(data.JsonElement.GetProperty(nameof(Kind)).GetString());
            Data = Kind switch
            {
                DataKind.RawFileInfo => JObject.Parse(data.JsonElement.GetProperty(nameof(Data)).GetRawText()),
                DataKind.Duration => TimeSpan.Parse(data.JsonElement.GetProperty(nameof(Data)).GetString()),
                DataKind.ApproximateDuration => TimeSpan.Parse(data.JsonElement.GetProperty(nameof(Data)).GetString()),
                _ => null
            };
        }
    }
}
