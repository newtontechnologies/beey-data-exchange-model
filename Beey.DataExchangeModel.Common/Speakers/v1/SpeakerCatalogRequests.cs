using System.ComponentModel;

namespace Beey.DataExchangeModel.Common.Speakers.v1;


public class SpeakerCatalogRequestCreate
{
    public required SpeakerDto Speaker { get; set; }

    public required SpeakerCatalogScope Scope { get; set; }
}

public class SpeakerCatalogRequestList
{
    public RequestPage? Page { get; set; }

    public SpeakerCatalogScope? Scope { get; set; }
}

public class SpeakerCatalogRequestSuggest
{
    public required string Search { get; set; }

    /// <summary>Suggestion profile key, if null then first profile is used as default</summary>
    public required string? ProfileKey { get; set; }

    [DefaultValue(1000)] // for Swagger
    public int? Count { get; set; }

    public SpeakerCatalogScope? Scope { get; set; }

    /// <summary>IETF language tag (BCP 47, former RFC-4646)</summary>
    public string? Language { get; set; }
}

public class SpeakerCatalogRequestGet
{
    public required string SpeakerId { get; set; }

    public SpeakerCatalogScope? Scope { get; set; }
}

public class SpeakerCatalogRequestGetMultiple
{
    public required List<string> SpeakerIds { get; set; }

    public SpeakerCatalogScope? Scope { get; set; }
}

public class SpeakerCatalogRequestUpdate
{
    public required SpeakerDto Speaker { get; set; }

    public SpeakerCatalogScope? Scope { get; set; }
}

public class SpeakerCatalogRequestRedirect
{
    public required string FromSpeakerId { get; set; }

    public required string ToSpeakerId { get; set; }

    public required string FromSpeakerConcurrencyToken { get; set; }

    public SpeakerCatalogScope? Scope { get; set; }
}

public class SpeakerCatalogRequestDelete
{
    public required string SpeakerId { get; set; }

    public required SpeakerCatalogScope? Scope { get; set; }
}

public class SpeakerResultByIdDto
{
    /// <summary> Id of speaker which was requested originally </summary>
    public required string RequestedId { get; set; }

    /// <summary> Speaker found in the database; it can be another speaker if the original was redirected </summary>
    public required SpeakerDto Speaker { get; set; }
}

public class RequestPage
{
    [DefaultValue(0)]
    public int Skip { get; set; }

    [DefaultValue(1000)] // for Swagger
    public int Count { get; set; } = 1000;
}

