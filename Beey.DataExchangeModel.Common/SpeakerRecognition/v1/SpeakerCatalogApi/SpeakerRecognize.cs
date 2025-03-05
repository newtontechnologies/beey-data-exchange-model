using Beey.DataExchangeModel.Common.Speakers.v1;

namespace Beey.DataExchangeModel.Common.SpeakerRecognition.v1.SpeakerCatalogApi;

public class SpeakerRecognizeRequest
{
    public required byte[] Voiceprint { get; init; }

    /// <summary>Language IETF tag</summary>
    public required string Language { get; init; }

    public required string VoiceprintProfileId { get; init; }

    public required SpeakerCatalogScope Scope { get; init; }

    public SpeakerRecognizerVersion? RecognizerVersion { get; init; }

    public string[]? AlreadySeenSpeakerIds { get; init; }
}

public class SpeakerRecognizeReply
{
    public required string? SpeakerId { get; init; }

    public float? Probability { get; init; }
}

public enum SpeakerRecognizerVersion
{
    V2 = 2
}
