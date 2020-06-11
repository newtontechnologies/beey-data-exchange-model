using Beey.DataExchangeModel.Serialization;
using Beey.DataExchangeModel.Auth;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;

#pragma warning disable nullable
#pragma warning disable 8618, 8601, 8603
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

        [JsonIgnoreWeb]
        public string _mediaInfo { get; set; }
        [JsonIgnoreWebDeserialize]
        [NotMapped]
        public MediaInfo MediaInfo { get => _mediaInfo == null ? null : JsonSerializer.Deserialize<MediaInfo>(_mediaInfo); set => _mediaInfo = value is { } ? JsonSerializer.Serialize(value) : null; }

        [JsonIgnoreWebDeserialize]
        public int? RecordingId { get; set; }

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
