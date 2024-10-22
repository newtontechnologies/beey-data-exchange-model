namespace Beey.DataExchangeModel.Common.Voiceprints;

public class VoiceprintModelInfo
{
    public VoiceprintModelInfo() { }
    public VoiceprintModelInfo(string hash, float acceptanceThreshold)
    {
        Hash = hash;
        AcceptanceThreshold = acceptanceThreshold;
    }

    public required string Hash { get; set; }
    public required float AcceptanceThreshold { get; set; }
}
