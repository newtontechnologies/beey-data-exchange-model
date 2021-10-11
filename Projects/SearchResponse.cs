using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Projects
{
    public class SearchResponse
    {
        public int Total { set; get; }

        public SearchResult[] Results { set; get; }
    }

    public class SearchResult
    {
        public int ProjectId { set; get; }
       
        public string[] ProjectNameHighlight { set; get; }

        public string[] TranscriptionHighlight { set; get; }

        public string[] SpeakerHighlight { set; get; }

        public string[] NotesHighlight { set; get; }

    }
}
