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

public class RequestPage
{
    [DefaultValue(0)]
    public int Skip { get; set; }

    [DefaultValue(1000)]
    public int Count { get; set; }
}

