using System.Text.Json.Nodes;
using Beey.DataExchangeModel.Common.Speakers.v1;

namespace Beey.DataExchangeModel.Common.SpeakerRecognition.v1.SpeakerCatalogApi;

public class SpeakerRecognizeInitRequest
{
    /// <summary>Language IETF tag</summary>
    public required string Language { get; init; }

    public required string VoiceprintProfileId { get; init; }

    public required SpeakerCatalogScope Scope { get; init; }

    public SpeakerRecognizerVersion? RecognizerVersion { get; init; }
}

public class SpeakerRecognizeInitReply
{
    public required SpeakerRecognizerVersion RecognizerVersion { get; init; }

    public required JsonObject InitialState { get; init; }
}

public enum SpeakerRecognizerVersion
{
    V2 = 2
}
