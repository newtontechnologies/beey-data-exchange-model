using System.Text.Json.Nodes;

namespace Beey.DataExchangeModel.Common.SpeakerRecognition.v1.SpeakerCatalogApi;

public class SpeakerRecognizeRequest
{
    public required SpeakerRecognizerVersion RecognizerVersion { get; init; }

    public required byte[] Voiceprint { get; init; }

    public required JsonObject SessionState { get; init; }
}

public class SpeakerRecognizeReply
{
    public required string? SpeakerId { get; init; }

    public float? Probability { get; init; }

    public required JsonObject SessionState { get; init; }
}
