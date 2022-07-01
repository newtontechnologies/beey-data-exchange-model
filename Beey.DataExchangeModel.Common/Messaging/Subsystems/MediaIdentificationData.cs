using Beey.DataExchangeModel.Projects;
using Beey.DataExchangeModel.Serialization.JsonConverters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging.Subsystems;

public class MediaIdentificationData : SubsystemData<MediaIdentificationData>
{
    public enum DurationKind
    {
        Duration,
        ApproximateDuration,
        DurationlessStream,
        Error,
    }

    [JsonConverter(typeof(JsonStringNullableEnumConverter))]
    public DurationKind? Kind { get; set; }

    [JsonConverter(typeof(JsonNullableConverter<JsonTimeSpanConverter, TimeSpan>))]
    public TimeSpan? Duration { get; set; }
    public MediaInfo MediaInfo { get; set; }

    public string RawData { get; set; }
    public string Error { get; set; }
}
