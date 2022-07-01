using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Lexicons;

public class LexiconEntry
{
    public string Text { get; set; }
    public string Pronunciation { get; set; }

    public LexiconEntry(string text, string pronunciation)
    {
        Text = text ?? throw new ArgumentNullException(nameof(text));
        Pronunciation = pronunciation ?? throw new ArgumentNullException(nameof(pronunciation));
    }
}
