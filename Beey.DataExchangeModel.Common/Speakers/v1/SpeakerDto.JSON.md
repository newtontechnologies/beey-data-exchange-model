
# Speaker JSON structure v1

A complete example:

```json
{
    "firstName": "Vladimir",
    "lastName": {
        "*": "Zelenskyy",
        "cs": "Zelenský" },
    "defaultIsoLang": "uk-UA",
    "role": {
        "uk-UA": "Президент",
        "cs-CZ": "ukrajinský prezident"
    },
    "custom": [
    {
        "name": "a",
        "value": "something",
        "date": "2024-09-11T17:55:19.1126113+00:00" }
    ],
    "beey_custom_tag": "UK-flag"
}
```

This example shows multiple possible ways to express localized texts, languages etc.

The JSON structure is opened and you can find anything in the JSON data. All fields are optinal and you can even find fields to have different data types.

If you update the speaker you should always keep the other fields intact.

This document is a recommendation for best compatibility rather than a specification.

| Field | JSON type | Meaning | Example(s) | C# constant for the key |
|---|---|---|---|
| `"firstName"` | [localized text](#localized-texts) | First name | `"Vladimir"`, `{"cz-CZ": "Vladimír"}`, ... | `CommonSpeakerFields.FirstName` |
| `"middleName"` | [localized text](#localized-texts) | Middle name | `null`, `{}`, ... | `CommonSpeakerFields.MiddleName` |
| `"lastName"` | [localized text](#localized-texts) | Last name | `"Bind"`, `{"cz-CZ": ""}` | `CommonSpeakerFields.LastName` |
| `"degreeBefore"` | [localized text](#localized-texts) | Degree before | | `CommonSpeakerFields.DegreeBefore` |
| `"degreeAfter"` | [localized text](#localized-texts) | Degree after | | `CommonSpeakerFields.DegreeAfter` |
| `"imageBase64"` | text (base-64 encoded JPEG) | Thumbnail encoded in base64 | | `CommonSpeakerFields.ImageBase64` |
| `"defaultIsoLang"` | text ([language](#languages)) | Native language of the speaker | `"cs-CZ"` | `CommonSpeakerFields.DefaultIsoLang` |
| `"role"` | [localized text](#localized-texts) | Usual role of the person | `"secret agent"`, ... | `CommonSpeakerFields.Role` |
| `"custom"` | array of [custom attributes](#custom-attributes) | Attributes from/to TRSX | `[{"key": .., ..}]` | `CommonSpeakerFields.role` |
| any other fiels | any | There is no limit to which fields can be here | | |

# Localized texts

A localized text can be expressed as either:
1. _JSON text_, or
2. _JSON object_ with different texts for language

In the first case, the single text is used for all languages.

In the second case, the object has keys according to available [languages](#languages), or `"*"` for language-agnostic value.

| Field | JSON type | Example | Meaning |
|---|---|---|---|
| `"*"` | text | `"Zelenskyy"` | optional default (language-agnostic) version of the value |
| `"cs"` | text | `"Zelenský"` | optional Czech translation |
| `"de-DE"` | text | `"Selenskyj"` | optional German translation |
| other | text | `...` | any unexpected translations may be also present |

If you need specific version for your language and it's not there, you should use the `"*"` version. If that version is not found either, you should use the first version in the list.

# Custom attributes

The custom attributes are here only for compatibility with TRSX attributes. Each of then can have these fields (all optional):

| Field | JSON type | C# mapping |
|---|---|---|
| `"name"` | text | `SpeakerAttribute.Name` |
| `"id"` | text | `SpeakerAttribute.ID` |
| `"value"` | text | `SpeakerAttribute.Value` |
| `"date"` | text (ISO 8601-1:2019 date/time) | `SpeakerAttribute.Date` |

# Languages

Language codes are based on IETF language tag (RFC-4646). Usually the tag can have one of two forms:
* `"cs"` – just the language code
* `"cs-CZ"` – includes also country/region code

Both forms are possible. The two-letter language code is defined by to ISO 639 while ISO 3166 defines country/region codes.

The language code is case-sensitive. Any unknown language code should be accepted as well (just process it as an unknown language).
