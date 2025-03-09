namespace Beey.DataExchangeModel.Common.Voiceprints.v1.SpeakerCatalogApi;

public class VoiceprintCreateRequest
{
    public required string SpeakerId { get; init; }

    /// <summary>IETF tag or null if language is unknown</summary>
    /// <remarks>
    /// This should be set if catalog is in model-per-language mode,
    /// otherwise this voiceprint might not be used at all.
    /// </remarks>
    public required string? Language { get; set; }

    public required string ProfileId { get; init; }

    /// <summary>Voice-print as binary data</summary>
    public required byte[] Data { get; init; }
}

public class VoiceprintCreateResponse
{
    /// <summary>Id of created voiceprint</summary>
    public required int Id { get; init; }
}
