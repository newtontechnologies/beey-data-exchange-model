namespace Beey.DataExchangeModel.Common.Speakers;

public static class CommonSpeakerFields
{
    public static SpeakerLocalizedStringField FirstName { get; } = new("firstName", TextReadOptions());

    public static SpeakerLocalizedStringField MiddleName { get; } = new("middleName", TextReadOptions());

    public static SpeakerLocalizedStringField LastName { get; } = new("lastName", TextReadOptions());

    public static SpeakerLocalizedStringField DegreeBefore { get; } = new("degreeBefore", TextReadOptions());

    public static SpeakerLocalizedStringField DegreeAfter { get; } = new("degreeAfter", TextReadOptions());

    public static SpeakerStringField ImageBase64 { get; } = new("imageBase64", TextReadOptions());

    public static SpeakerStringField DefaultIsoLang { get; } = new("defaultIsoLang", TextReadOptions());

    public static SpeakerLocalizedStringField Role { get; } = new("role", TextReadOptions());

    static SpeakerDataStringReadOptions TextReadOptions() => new()
    {
        ReadNumberAsString = false,
        ReadValuesFromObjects = false,
        StringJoinCharacter = " "
    };
}

public class SpeakerStringField(string fieldName, SpeakerDataStringReadOptions? options) : SpeakerFieldBase(fieldName)
{
    public SpeakerDataStringReadOptions? StringReadOptions { get; } = options;
}

public class SpeakerLocalizedStringField(string fieldName, SpeakerDataStringReadOptions? options) : SpeakerFieldBase(fieldName)
{
    public SpeakerDataStringReadOptions? StringReadOptions { get; } = options;
}

public class SpeakerFieldBase(string fieldName)
{
    public string FieldName { get; } = fieldName;

    public override string ToString() => FieldName;
}
