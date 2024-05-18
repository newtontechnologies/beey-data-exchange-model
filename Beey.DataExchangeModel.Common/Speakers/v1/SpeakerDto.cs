using System.ComponentModel;
using System.Text.Json.Nodes;

namespace Beey.DataExchangeModel.Common.Speakers.v1;

public class SpeakerDto
{
    /// <summary> Global unique Id, used to identify person across multiple databases </summary>
    [DefaultValue(null)]
    public string? UniqueId { get; set; }

    public required SpeakerData Data { get; set; }

    /// <summary> Token checked by the database to see if the data has changed in the meantime by another user </summary>
    /// <remarks>
    /// Speaker database should implement optimistic concurrency, which means it generates a new token every time the item is updated.
    /// If you are updating the speaker, you should send the same token you received last time.
    /// The database checks if the token stored is the same as the one you provided, and if it is different,
    /// it means somebody else has changed the item in the meantime without your knowledge.
    /// In such case the update is rejected, and you should inform the user about the update conflict.
    /// </remarks>
    [DefaultValue(null)]
    public string? ConcurrencyToken { get; set; }
}

public class SpeakerData
{
    /// <summary> Any JSON data associated with the speaker </summary>
    public JsonObject Json { get; set; } = new();

    /// <summary> Version of JSON data schema </summary>
    /// <remarks> This can be used in case of breaking changes of the schema in the future. </remarks>
    [DefaultValue(LatestSchemaVersion)]
    public int Schema { get; set; } = LatestSchemaVersion;

    public const int LatestSchemaVersion = 1;
}
