using System.Text.Json.Nodes;

namespace Beey.DataExchangeModel.Common.Speakers;
public static class SpeakerDtoExtensions
{
    public static string? GetString(this SpeakerDto dto, SpeakerField field)
        => dto.Data.TryGetPropertyValue(field.FieldName, out var propertyNode)
           && propertyNode is JsonValue propertyValue
           && propertyValue.TryGetValue<string>(out var value)
            ? value
            : null;

    public static void SetString(this SpeakerDto dto, SpeakerField field, string? newValue)
    {
        if (newValue == null)
            dto.Data.Remove(field.FieldName);
        else
            dto.Data[field.FieldName] = JsonValue.Create(newValue);
    }
}
