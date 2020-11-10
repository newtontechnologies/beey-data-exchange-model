using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.BeeySystem
{
    public enum AnnouncementImportance { Low, Normal, High, Critical }

    public partial class Announcement : EntityBase
    {
        [System.Text.Json.Serialization.JsonIgnore][Newtonsoft.Json.JsonIgnore]
        [Column("From")]
        public DateTime FromUtc { get; set; }
        [System.Text.Json.Serialization.JsonIgnore][Newtonsoft.Json.JsonIgnore]
        [Column("To")]
        public DateTime ToUtc { get; set; }

        // MySQL does not support DateTimeOffset.
        [NotMapped]
        public DateTimeOffset From { get => new DateTimeOffset(FromUtc, TimeSpan.Zero); set => FromUtc = value.UtcDateTime; }
        [NotMapped]
        public DateTimeOffset To { get => new DateTimeOffset(ToUtc, TimeSpan.Zero); set => ToUtc = value.UtcDateTime; }

        public AnnouncementImportance Importance { get; set; }
        public AnnouncementTemplate Template { get; set; }
        public string TemplateParameters { get; set; }
        public string Localizations { get; set; }
    }
}
