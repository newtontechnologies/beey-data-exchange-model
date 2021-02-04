using Beey.DataExchangeModel.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
#if BeeyServer
using System.ComponentModel.DataAnnotations.Schema;
#endif
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.BeeySystem
{
    public enum AnnouncementImportance { Low, Normal, High, Critical }

    public partial class Announcement : EntityBase
    {
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [Column("From")]
        public DateTime FromUtc { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [Column("To")]
        public DateTime ToUtc { get; set; }

        // MySQL does not support DateTimeOffset.
        [NotMapped]
        public DateTimeOffset From { get => new DateTimeOffset(FromUtc, TimeSpan.Zero); set => FromUtc = value.UtcDateTime; }
        [NotMapped]
        public DateTimeOffset To { get => new DateTimeOffset(ToUtc, TimeSpan.Zero); set => ToUtc = value.UtcDateTime; }

        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public AnnouncementImportance Importance { get; set; }

        public AnnouncementTemplate Template { get; set; }

        [JsonIgnoreWeb]
        [Column("TemplateParameters")]
        public string _TemplateParameters { get; set; }
        [NotMapped]
        public JArray TemplateParameters
        {
            get => _TemplateParameters == null ? null : JArray.Parse(_TemplateParameters);
            set => _TemplateParameters = value?.ToString();
        }

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
