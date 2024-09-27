﻿namespace Beey.DataExchangeModel.Common.VoiceSamples.v1.SpeakerCatalogApi;

public class VoiceSampleListRequest
{
    // all properties are query params

    public int? Id { get; set; }

    public string? SpeakerId { get; set; }

    public bool? FileReady { get; set; }

    public int? Skip { get; set; }

    public int? Count { get; set; }

    public string? TenantId { get; set; }
}

public class VoiceSampleListResponse
{
    public required Listing<VoiceSampleDto> Samples { get; init; }
}
