using Beey.DataExchangeModel.Common.Speakers.v1;

namespace Beey.DataExchangeModel.Common.VoiceSamples.v1.SpeakerCatalogApi;

public class VoiceSampleUpdateRequest
{
    public required string SpeakerId { get; init; }

    public required string? FileName { get; init; }

    public required DateTimeOffset? Recorded { get; init; }

    /// <summary>If set, the bytes of the sample are updated</summary>
    public byte[]? NewData { get; init; }

    public required string ConcurrencyToken { get; init; }

    /// <summary>If set the speaker catalog will validate if the tenant has access to the given speaker</summary>
    public SpeakerCatalogScope? Scope { get; set; }
}

public class VoiceSampleUpdateResponse
{
    public required VoiceSampleDto Sample { get; init; }
}
