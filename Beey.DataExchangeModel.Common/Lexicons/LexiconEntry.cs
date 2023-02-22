using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Lexicons;

public class LexiconEntry
{
    public string Text { get; }
    public string IncorrectTranscription { get; }

    [Obsolete("Only for backward compatibility with Broadcast NG model.")]
    public string? Pronunciation { get; }

    [JsonConstructor]
    public LexiconEntry(string text, string? pronunciation, string? incorrectTranscription = null)
    {
        Text = text ?? throw new ArgumentNullException(nameof(text));
        Pronunciation = pronunciation;
        IncorrectTranscription = incorrectTranscription ?? text;
    }
}
