namespace Beey.DataExchangeModel.Common.Voiceprints.v1;

public class VoiceprintDto
{
    public required int Id { get; init; }

    public required string SpeakerId { get; init; }

    public required string ProfileId { get; init; }

    /// <summary>Voice-print as binary data</summary>
    public required byte[] Data { get; init; }
}
