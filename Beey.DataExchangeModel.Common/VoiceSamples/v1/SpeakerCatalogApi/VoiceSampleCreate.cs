namespace Beey.DataExchangeModel.Common.VoiceSamples.v1.SpeakerCatalogApi;

public class VoiceSampleCreateRequest
{
    public required string SpeakerId { get; set; }

    public required string? FileName { get; set; }

    public required DateTimeOffset? Recorded { get; init; }

    public byte[]? Data { get; set; }
}

public class VoiceSampleCreateResponse
{
    public required VoiceSampleDto Sample { get; set; }
}
