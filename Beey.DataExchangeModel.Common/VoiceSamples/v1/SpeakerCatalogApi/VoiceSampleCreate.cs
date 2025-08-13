using System.Text.Json.Nodes;
using Beey.DataExchangeModel.Common.Speakers.v1;

namespace Beey.DataExchangeModel.Common.VoiceSamples.v1.SpeakerCatalogApi;

public class VoiceSampleCreateRequest
{
    public required string SpeakerId { get; set; }

    /// <summary>IETF tag or null if language is unknown</summary>
    public string? Language { get; set; } = null;

    public required string? FileName { get; set; }

    public required JsonObject? Metadata { get; set; }

    [Obsolete("Use Metadata instead")]
    public DateTimeOffset? Recorded { get; init; }

    public byte[]? Data { get; set; }

    /// <summary>If set the speaker catalog will validate if the tenant has access to the given speaker</summary>
    public SpeakerCatalogScope? Scope { get; set; }
}

public class VoiceSampleCreateResponse
{
    public required VoiceSampleDto Sample { get; set; }
}
