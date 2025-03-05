namespace Beey.DataExchangeModel.Common.VoiceSamples.v1.SpeakerCatalogApi;

public class VoiceSampleListRequest
{
    // all properties are query params

    public int? Id { get; set; }

    public string? SpeakerId { get; set; }

    /// <summary>
    /// IETF tag;
    /// empty = get samples with undefined language
    /// null = get samples of all languages
    /// </summary>
    public string? Language { get; set; } = null;

    public bool? FileReady { get; set; }

    public int? Skip { get; set; }

    public int? Count { get; set; }

    public string? TenantId { get; set; }
}

public class VoiceSampleListResponse
{
    public required Listing<VoiceSampleDto> Samples { get; init; }
}
