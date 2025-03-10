namespace Beey.DataExchangeModel.Common.Voiceprints.v1;

public class VoiceprintDto
{
    public required long Id { get; init; }

    public required string SpeakerId { get; init; }

    /// <summary>IETF tag or null if language is unknown</summary>
    public required string? Language { get; set; }

    public required string ProfileId { get; init; }

    /// <summary>Voice-print as binary data</summary>
    public required byte[] Data { get; init; }
}
