using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Lexicons;

public class LexiconEntry
{
    public string Text { get; }
    public string IncorrectTranscription { get; }

    public LexiconEntry(string text, string incorrectTranscription)
    {
        Text = text ?? throw new ArgumentNullException(nameof(text));
        IncorrectTranscription = incorrectTranscription ?? text;
    }
}
