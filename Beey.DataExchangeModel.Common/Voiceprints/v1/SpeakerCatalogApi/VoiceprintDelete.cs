using Beey.DataExchangeModel.Common.Speakers.v1;

namespace Beey.DataExchangeModel.Common.Voiceprints.v1.SpeakerCatalogApi;

public class VoiceprintDeleteRequest
{
    public string? TenantId { get; set; } // query param
}

public class VoiceprintDeleteResponse
{
}

public class VoiceprintBatchDeleteRequest
{
    public required long[] Ids { get; init; }

    public SpeakerCatalogScope? Scope { get; init; }
}

public class VoiceprintBatchDeleteResponse
{
    public int DeletedCount { get; init; }
}
