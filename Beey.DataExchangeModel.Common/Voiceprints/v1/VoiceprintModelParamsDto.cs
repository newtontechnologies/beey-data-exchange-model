namespace Beey.DataExchangeModel.Common.Voiceprints.v1;

public class VoiceprintModelParamsDto
{
    public required string Version { get; init; }
    public required int NeighborsCount { get; init; }
    public required float Threshold { get; init; }
    public required float ThresholdRecurring { get; init; }
    public required float RequiredBestMatchDistance { get; init; }
    public required float RequiredBestMatchDistanceRecurring { get; init; }
}
