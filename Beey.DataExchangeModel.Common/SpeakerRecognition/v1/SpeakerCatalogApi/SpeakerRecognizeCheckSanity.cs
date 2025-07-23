using System.Text.Json.Nodes;
using Beey.DataExchangeModel.Common.Speakers.v1;
using Beey.DataExchangeModel.Common.SpeakerRecognition.v1.SpeakerCatalogApi;


public class SpeakerRecognizeCheckSanityRequest
{
    /// <summary>Language IETF tag</summary>
    public required string Language { get; init; }

    public required string VoiceprintProfileId { get; init; }

    public required SpeakerCatalogScope Scope { get; init; }

    public SpeakerRecognizerVersion? RecognizerVersion { get; init; }
}

public class SpeakerRecognizeCheckSanityReply
{
    public required JsonObject ResponseContent { get; init; }
}
