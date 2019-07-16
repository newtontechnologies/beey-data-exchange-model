using Beey.DataExchangeModel.Serialization;
using Beey.DataExchangeModel.Auth;
using Beey.DataExchangeModel.Files;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

#pragma warning disable nullable
namespace Beey.DataExchangeModel.Projects
{
    public partial class Project : ConcurrentEntity
    {
        [JsonIgnoreWebDeserialize]
        public TimeSpan Length { get; set; }

        [JsonIgnoreWebDeserialize]
        public long Size { get; set; }
        public string Name { get; set; }

        [JsonIgnoreWeb]
        public string _tags { get; set; }
        [JsonIgnoreWeb]
        public string _settings { get; set; }
        [NotMapped]
        public JArray Tags { get => _tags == null ? null : JArray.Parse(_tags); set => _tags = value?.ToString(); }
        [NotMapped]
        public JObject Settings { get => _settings == null ? null : JObject.Parse(_settings); set => _settings = value?.ToString(); }

        [JsonIgnoreWebDeserialize]
        public int? RecordingId { get; set; }
        [JsonIgnoreWebDeserialize]
        public FileWrapper Recording { get; set; }
        [JsonIgnoreWebDeserialize]
        public int? OriginalTrsxId { get; set; }
        [JsonIgnoreWebDeserialize]
        public FileWrapper OriginalTrsx { get; set; }
        [JsonIgnoreWebDeserialize]
        public int? CurrentTrsxId { get; set; }
        [JsonIgnoreWebDeserialize]
        public FileWrapper CurrentTrsx { get; set; }


        [JsonIgnoreWebDeserialize]
        public int CreatorId { get; set; }
        [JsonIgnoreWeb]
        public User Creator { get; set; }

        [JsonIgnoreWeb]
        public ICollection<ProjectAccess> ProjectAcesses { get; set; }

        [JsonIgnoreWebDeserialize]
        public int ShareCount { get; set; }
    }
}
