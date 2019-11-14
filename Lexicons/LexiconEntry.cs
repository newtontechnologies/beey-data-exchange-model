﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Lexicons
{
    public class LexiconEntry
    {
        [JsonProperty(Required = Required.Always)]
        public string Text { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Pronunciation { get; set; }
        
        public LexiconEntry(string text, string pronunciation)
        {
            Text = text;
            Pronunciation = pronunciation;
        }
    }
}
