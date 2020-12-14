using Beey.DataExchangeModel.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.BeeySystem
{
    public class AnnouncementTemplate : EntityBase
    {
        [JsonIgnoreWeb]
        [Column("Localizations")]
        public string _Localizations { get; set; }
        [NotMapped]
        public JObject Localizations
        {
            get => _Localizations == null ? null : JObject.Parse(_Localizations);
            set => _Localizations = value?.ToString();
        }
    }
}
