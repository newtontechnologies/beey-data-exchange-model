namespace Beey.DataExchangeModel.Common.Speakers;

/// <summary> Common well-known speaker field </summary>
public readonly struct SpeakerField(string fieldName)
{
    public string FieldName { get; } = fieldName;
    public override string ToString() => this.FieldName;

    public static SpeakerField FirstName { get; } = new("firstName");

    public static SpeakerField MiddleName { get; } = new("middleName");

    public static SpeakerField LastName { get; } = new("lastName");

    public static SpeakerField DegreeBefore { get; } = new("degreeBefore");

    public static SpeakerField DegreeAfter { get; } = new("degreeAfter");

    public static SpeakerField ImageBase64 { get; } = new("imageBase64");

    public static SpeakerField DefaultIsoLang { get; } = new("defaultIsoLang");

    public static SpeakerField Role { get; } = new("role");
}
