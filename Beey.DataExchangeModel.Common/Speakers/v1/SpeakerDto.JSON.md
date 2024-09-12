
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

Follow these rules for working with the format:
* Expect anything and always do the best effort to interpret the values the best way you can.
* If you can't localized text for your language, implement fallback to other language or neutral variant.
* The actual format can be always different from the specification. Don't throw exceptions, just read all the fields you can instead.
* Preserve as much original data as possible when updating the structure.

| Field | JSON type | Meaning | Example(s) | C# constant for the key |
|---|---|---|---|---|
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
| `"*"` | text | `"Zelenskyy"` | optional neutral version of the value |
| `"cs"` | text | `"Zelenský"` | optional Czech translation |
| `"de-DE"` | text | `"Selenskyj"` | optional German translation |
| other | text | `...` | any unexpected translations may be also present |

If you need specific version for your language and it's not there, you should use the neutral versio, or first version in the list.

# Custom attributes

The custom attributes are here only for compatibility with TRSX attributes. Each of then can have these fields (all optional):

| Field | JSON type | C# mapping |
|---|---|---|
| `"name"` | text | `SpeakerAttribute.Name` |
| `"id"` | text | `SpeakerAttribute.ID` |
| `"value"` | text | `SpeakerAttribute.Value` |
| `"date"` | text (ISO 8601-1:2019 date/time) | `SpeakerAttribute.Date` |

# Languages

Language codes are based on IETF language tag (BCP 47, former RFC-4646). Usually the tag can have one of two forms:
* `"cs"` – just the language code (ISO 639)
* `"cs-CZ"` – includes also country/region code (ISO 3166)

Both forms are possible. The language code is case-insensitive. Any unknown language code should be accepted as well (just process it as an unknown language).

All these variants have the same meaning: `"cs-CZ"`, `"CS-CZ"`, `"cs-cz"`, `"cs"`, `"CS"` (just like in [.NET](https://sharplab.io/#v2:EYLgtghglgdgNAFxAJwK7wCYgNQB8ACADAAT4CMAdAOIA2A9sBDVAF4QJR0wDcAsAFD4ATGQECAKgFMAzggAUAIgDG0gLQBhAFoKAlH35TZi9QGUN2vRJnzlapS137DNlY6tGFpt/wH4ALMTOcuQkNDrEALwAfKRkAJxy6qg0CKjIkgCSMABmdBTq6eySJgAOkkpQ2VBKSSlpknJhFAAy6hkAInpAA==)). When you have doubts, you can try [BCP 47 validator](https://schneegans.de/lv/).

# Reading localized texts

This procedure considers one parameter: optional requested language.

* If direct text value is stored then it is the result no matter what language was requested
* If field is stored as localized (JSON object), then:
  * If a language was requested (not null), then:
    * If there is an _exact match_ (see below) then the first exact value is the result
    * If there is a _weak match_ (see below) then the first matching value is the result
  * If there is a neutral value (key `"*"`) then it's value is the result
  * If there is any value at all, the first value is the result
* In any other case result is `null`

_Exact match_ means that requested language and stored localized variant have the same language code AND country/culture code. Comparison is case-insensitive.

_Weak match_ means that requested language and stored localized variant have only the same language code. Comparison is case-insensitive.
