﻿using Beey.DataExchangeModel.Common.Speakers.v1;

namespace Beey.DataExchangeModel.Common.Voiceprints.v1.SpeakerCatalogApi;

public class VoiceprintListRequest
{
    // all properties are query params

    /// <summary>Filter only to specific speaker</summary>
    public string? SpeakerId { get; init; }

    /// <summary>Filter only to voice-prints generated with specific profile</summary>
    public string? Profile { get; init; }

    /// <summary>
    /// IETF tag;
    /// empty = get samples with undefined language
    /// null = get samples of all languages
    /// </summary>
    public string? Language { get; init; } = null;

    /// <summary>Filter only to voice-prints generated from specific voice-sample</summary>
    public int? SourceSampleId { get; init; }

    /// <summary>Whenever or not the response should include also details of all speakers of listed voice-prints</summary>
    public bool IncludeSpeakers { get; init; }

    public int? Skip { get; set; }

    public int? Count { get; set; }

    public string? TenantId { get; init; }
}

public class VoiceprintListResponse
{
    public required Listing<VoiceprintDto> Voiceprints { get; init; }

    /// <summary>Speakers as referenced by voice-prints</summary>
    public Dictionary<string, SpeakerDto>? Speakers { get; init; }

    public VoiceprintModelParamsDto? ModelParams { get; init; }
}
