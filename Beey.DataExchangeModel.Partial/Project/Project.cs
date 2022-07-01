using Beey.DataExchangeModel.Serialization;
using Beey.DataExchangeModel.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Beey.DataExchangeModel.Messaging.Subsystems;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;

#pragma warning disable nullable
#pragma warning disable 8618, 8601, 8603
namespace Beey.DataExchangeModel.Projects;

public partial class Project : ConcurrentEntity
{
    public string? Name { get; set; }
    public TimeSpan Length { get; set; }

    [JsonIgnore]
    public string? _tags { get; set; }
    public JsonArray Tags { get => _tags == null ? null : (JsonArray)JsonNode.Parse(_tags)!; set => _tags = value?.ToJsonString(); }

    [JsonIgnore]
    public string? _mediaInfo { get; set; }
    public MediaInfo MediaInfo { get => _mediaInfo == null ? null : JsonSerializer.Deserialize<MediaInfo>(_mediaInfo); set => _mediaInfo = value is { } ? JsonSerializer.Serialize(value) : null; }

    public int? RecordingId { get; set; }

    public int? MediaFileId { get; set; }

    public int? AudioFileId { get; set; }

    public int? VideoFileId { get; set; }


    public int? IndexFileId { get; set; }

    public int? OriginalTrsxId { get; set; }
    public int? CurrentTrsxId { get; set; }
    public int? CreatorId { get; set; }

    public int ShareCount { get; set; } = 1;

    [JsonIgnore]
    public string? _transcriptionConfig { get; set; }

    public TranscriptionConfig TranscriptionConfig
    {
        get => _transcriptionConfig == null ? null : JsonSerializer.Deserialize<TranscriptionConfig>(_transcriptionConfig);
        set => _transcriptionConfig = value is { } ? JsonSerializer.Serialize(value) : null;
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ProjectProcessingState ProcessingState
    {
        get; set;
    }
}
