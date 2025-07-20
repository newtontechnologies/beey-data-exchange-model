using Beey.DataExchangeModel.Common.SpeakerRecognition.v1.SpeakerCatalogApi;
using Beey.DataExchangeModel.Common.Speakers.v1;

namespace Beey.DataExchangeModel.Common.SpeakerRecognition.v1;

public class SpeakerRecognitionCustomizationDto
{
    public required int Id { get; init; }

    /// <summary>Customized language (IETF tag) or null if all languages are addressed</summary>
    public string? TargetLanguage { get; set; } = null;

    /// <summary>Customized voiceprint profile or null if all profiles are addressed</summary>
    public string? TargetVoiceprintProfileId { get; set; } = null;

    /// <summary>Customized recognition version or null if all versions are addressed</summary>
    public SpeakerRecognizerVersion? TargetRecognizerVersion { get; init; }

    /// <summary>Customized scope or null if all scopes are addressed</summary>
    public SpeakerCatalogScope? TargetScope { get; set; }

    /// <summary>If model auto-generation should be disabled, or null if this customization has no effect on this setting</summary>
    public bool? DisableModelGeneration { get; set; }
}
