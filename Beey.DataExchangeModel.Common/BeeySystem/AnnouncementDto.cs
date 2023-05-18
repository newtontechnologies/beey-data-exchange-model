using Beey.DataExchangeModel.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.BeeySystem;

public class AnnouncementDto : EntityDtoBase
{
    [JsonIgnore]
    public DateTime FromUtc { get; set; }
    [JsonIgnore]
    public DateTime ToUtc { get; set; }

    // MySQL does not support DateTimeOffset.
    public DateTimeOffset From { get => new DateTimeOffset(FromUtc, TimeSpan.Zero); set => FromUtc = value.UtcDateTime; }
    public DateTimeOffset To { get => new DateTimeOffset(ToUtc, TimeSpan.Zero); set => ToUtc = value.UtcDateTime; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AnnouncementImportance Importance { get; set; }

    [JsonIgnore]
    public string? _Localizations { get; set; }
    public JsonObject? Localizations
    {
        get => _Localizations == null ? null : (JsonObject)JsonNode.Parse(_Localizations)!;
        set => _Localizations = value?.ToJsonString();
    }
}
