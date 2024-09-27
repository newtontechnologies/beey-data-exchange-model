using System.ComponentModel;
using Beey.DataExchangeModel.Transcriptions;

namespace Beey.DataExchangeModel.Common.Speakers.v1;

/// <summary> Scope in which a speaker is valid </summary>
public class SpeakerCatalogScope
{
    [DefaultValue(DBSpeaker.GlobalId)]
    public required string TenantId { get; init; } = DBSpeaker.GlobalId;

    public static SpeakerCatalogScope? CreateNullable(string? tenantId)
        => tenantId is null ? null : new SpeakerCatalogScope { TenantId = tenantId };
}
