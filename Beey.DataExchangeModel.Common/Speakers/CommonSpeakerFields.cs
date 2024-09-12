namespace Beey.DataExchangeModel.Common.Speakers;

public static class CommonSpeakerFields
{
    public static SpeakerLocalizedStringField FirstName { get; } = new("firstName");

    public static SpeakerLocalizedStringField MiddleName { get; } = new("middleName");

    public static SpeakerLocalizedStringField LastName { get; } = new("lastName");

    public static SpeakerLocalizedStringField DegreeBefore { get; } = new("degreeBefore");

    public static SpeakerLocalizedStringField DegreeAfter { get; } = new("degreeAfter");

    public static SpeakerStringField ImageBase64 { get; } = new("imageBase64");

    public static SpeakerStringField DefaultIsoLang { get; } = new("defaultIsoLang");

    public static SpeakerLocalizedStringField Role { get; } = new("role");
}

public readonly record struct SpeakerStringField(string FieldName)
{
    public override string ToString() => this.FieldName;
}


public readonly record struct SpeakerLocalizedStringField(string FieldName)
{
    public override string ToString() => this.FieldName;
}
