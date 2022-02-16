using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Projects
{
    public class SearchResult
    {
        public Project Project { set; get; }

        public string[] ProjectNameHighlight { set; get; }

        public SearchResultTranscriptionHighlight[] TranscriptionHighlight { set; get; }

        public string[]? SpeakerHighlight { set; get; }

        public string[] NotesHighlight { set; get; }

    }

    public class SearchResultTranscriptionHighlight
    {
        public string Text { set; get; }

        public int Timestamp { set; get; }
    }
}
