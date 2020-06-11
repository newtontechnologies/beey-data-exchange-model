using Beey.DataExchangeModel.Serialization.JsonConverters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class MediaIdentificationData : SubsystemData<MediaIdentificationData>
    {
        public enum DurationKind
        {
            Duration,
            ApproximateDuration,
            DurationlessStream,
        }

        [JsonConverter(typeof(JsonStringNullableEnumConverter))]
        public DurationKind? Kind { get; set; }

        [JsonConverter(typeof(JsonNullableConverter<JsonTimeSpanConverter, TimeSpan>))]
        public TimeSpan? Duration { get; set; }

        public string RawData { get; set; }
    }
}
