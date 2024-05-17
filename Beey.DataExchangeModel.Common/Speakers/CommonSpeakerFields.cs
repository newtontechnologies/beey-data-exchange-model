namespace Beey.DataExchangeModel.Common.Speakers;

public static class CommonSpeakerFields
{
    public static SpeakerStringField FirstName { get; } = new("firstName");

    public static SpeakerStringField MiddleName { get; } = new("middleName");

    public static SpeakerStringField LastName { get; } = new("lastName");

    public static SpeakerStringField DegreeBefore { get; } = new("degreeBefore");

    public static SpeakerStringField DegreeAfter { get; } = new("degreeAfter");

    public static SpeakerStringField ImageBase64 { get; } = new("imageBase64");

    public static SpeakerStringField DefaultIsoLang { get; } = new("defaultIsoLang");

    public static SpeakerStringField Role { get; } = new("role");
}

public readonly record struct SpeakerStringField(string FieldName)
{
    public override string ToString() => this.FieldName;
}
