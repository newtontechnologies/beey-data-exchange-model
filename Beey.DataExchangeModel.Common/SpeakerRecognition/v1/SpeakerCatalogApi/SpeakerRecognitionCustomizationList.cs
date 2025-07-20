namespace Beey.DataExchangeModel.Common.SpeakerRecognition.v1.SpeakerCatalogApi;

public class SpeakerRecognitionCustomizationListRequest
{
    /// <summary>Find customizations for this language, or for all if this is null</summary>
    public string? Language { get; set; } = null;

    /// <summary>Find customizations for this voiceprint profile, or for all if this is null</summary>
    public string? VoiceprintProfileId { get; set; } = null;

    /// <summary>Find customizations for this recognition version, or for all if this is null</summary>
    public SpeakerRecognizerVersion? RecognizerVersion { get; init; }

    /// <summary>Find customizations for this tenant, or for all if this is null</summary>
    public string? TenantId { get; set; }
}

public class SpeakerRecognitionCustomizationListResponse
{
    public required Listing<SpeakerRecognitionCustomizationDto> Customizations { get; init; }
}
