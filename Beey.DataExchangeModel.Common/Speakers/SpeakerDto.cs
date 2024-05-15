using System.Text.Json.Nodes;

namespace Beey.DataExchangeModel.Common.Speakers;

public class SpeakerDto
{
    /// <summary> Global unique Id, used to identify person across multiple databases </summary>
    public string? UniqueId { get; set; }

    /// <summary> Any data associated with the speaker </summary>
    public JsonObject Data { get; set; } = new();

    /// <summary> Version of Data schema </summary>
    /// <remarks>
    /// This will be used if any breaking changes happen in Data in the future.
    /// At this moment always expect and set 1.
    /// </remarks>
    public int DataSchema { get; set; } = 1;

    /// <summary> Token checked by the database to see if the data has changed in the meantime by another user </summary>
    /// <remarks>
    /// Speaker database should implement optimistic concurrency, which means it generates a new token every time the item is updated.
    /// If you are updating the speaker, you should send the same token you received last time.
    /// The database checks if the token stored is the same as the one you provided, and if it is different,
    /// it means somebody else has changed the item in the meantime without your knowledge.
    /// In such case the update is rejected, and you should inform the user about the update conflict.
    /// </remarks>
    public string? ConcurrencyToken { get; set; }
}
