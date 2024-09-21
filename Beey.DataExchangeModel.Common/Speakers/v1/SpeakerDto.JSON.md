
# Generic speaker JSON structure v1

An example:

```json
{
  "UniqueId": null,
  "Data": {
    "Neutral": {
      "firstName": "Wall-E"
    },
    "Localizations": {
      "cs-CZ": {
        "firstName": "WALL-I"
      }
    },
    "Schema": 1
  },
  "ConcurrencyToken": null
}
```

The actual data are in these nodes:

| Field | Meaning |
|---|---|
| `"Neutral"` | Contains language-neutral data of the speaker |
| `"Localizations"` | Contains language-specific data of the speaker |

Language-specific data are stored as a dictionary where key is a [language tag](#language-tag).

Follow these rules for working with the format:
* Expect anything and always do the best effort to interpret the values the best way you can.
* If you can't find localized text for your language, implement fallback to other language or neutral variant (see below).
* The actual format can be always different from the specification. Don't throw exceptions, just read all the fields you can instead.
* Preserve as much original data as possible when updating the structure.

# Reading a localized field

Always check various nodes when searching for the value. Some value is always better than no value.

If you are reading in language-agnostic context, your priority order should go like this:
1. `Neutral` node
2. `Localizations` subnodes in no particular order

If you are reading value for specific language, your priority order should differ:
1. `Localizations` subnode exactly for your language (note that key is case-insensitive and `cs-CZ` equals `cs-cz`)
2. `Localizations` subnode with "similar" language (with the same language code, for example `cs-CZ` is similar to `CS`)
3. `Neutral` node

# Language tag

Language codes are based on IETF language tag (BCP 47, former RFC-4646). Usually the tag can have one of two forms:
* `"cs"` – just the language code (ISO 639)
* `"cs-CZ"` – includes also country/region code (ISO 3166)

Both forms are possible. The language code is case-insensitive. Any unknown language code should be accepted as well (just process it as an unknown language).

All these variants have the same meaning: `"cs-CZ"`, `"CS-CZ"`, `"cs-cz"`, `"cs"`, `"CS"` (just like in [.NET](https://sharplab.io/#v2:EYLgtghglgdgNAFxAJwK7wCYgNQB8ACADAAT4CMAdAOIA2A9sBDVAF4QJR0wDcAsAFD4ATGQECAKgFMAzggAUAIgDG0gLQBhAFoKAlH35TZi9QGUN2vRJnzlapS137DNlY6tGFpt/wH4ALMTOcuQkNDrEALwAfKRkAJxy6qg0CKjIkgCSMABmdBTq6eySJgAOkkpQ2VBKSSlpknJhFAAy6hkAInpAA==)). When you have doubts, you can try [BCP 47 validator](https://schneegans.de/lv/).

