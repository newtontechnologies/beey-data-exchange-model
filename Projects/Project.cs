using Beey.DataExchangeModel.Serialization;
using Beey.DataExchangeModel.Auth;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#pragma warning disable nullable
#pragma warning disable 8618,8601,8603
namespace Beey.DataExchangeModel.Projects
{
    public partial class Project : ConcurrentEntity
    {
        public string Name { get; set; }
        [JsonIgnoreWebDeserialize]
        public TimeSpan Length { get; set; }

        [JsonIgnoreWeb]
        public string _tags { get; set; }
        [JsonIgnoreWebDeserialize]
        [NotMapped]
        public JArray Tags { get => _tags == null ? null : JArray.Parse(_tags); set => _tags = value?.ToString(); }

        [JsonIgnoreWebDeserialize]
        public int? RecordingId { get; set; }
        [JsonIgnoreWebDeserialize]
        public int? AudioRecordingId { get; set; }
        [JsonIgnoreWebDeserialize]
        public int? VideoRecordingId { get; set; }
        [JsonIgnoreWebDeserialize]
        public int? RecordingManifestId { get; set; }

        [JsonIgnoreWebDeserialize]
        public int? MediaFileId { get; set; }
        [JsonIgnoreWebDeserialize]
        public int? IndexFileId { get; set; }

        [JsonIgnoreWebDeserialize]
        public int? OriginalTrsxId { get; set; }
        [JsonIgnoreWebDeserialize]
        public int? CurrentTrsxId { get; set; }
        [JsonIgnoreWebDeserialize]
        public int? CreatorId { get; set; }

        [JsonIgnoreWebDeserialize]
        public int ShareCount { get; set; } = 1;
    }
}
