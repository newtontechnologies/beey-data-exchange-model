using Beey.DataExchangeModel.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.BeeySystem
{
    public class AnnouncementTemplate : EntityBase
    {
        [JsonIgnoreWeb]
        public string? _Localizations { get; set; }
        public JObject? Localizations
        {
            get => _Localizations is null ? null : JObject.Parse(_Localizations);
            set => _Localizations = value?.ToString();
        }
    }
}
