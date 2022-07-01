using Beey.DataExchangeModel.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.BeeySystem;

public class AnnouncementTemplate : EntityBase
{
    [JsonIgnore]
    public string? _Localizations { get; set; }
    public JsonObject? Localizations
    {
        get => _Localizations is null ? null : (JsonObject)JsonNode.Parse(_Localizations)!;
        set => _Localizations = value?.ToString();
    }
}
