using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Projects
{   
    public class SearchResult
    {
        public int Id { set; get; }

        public Project Project { set; get; }

        public string[] ProjectNameHighlight { set; get; }

        public string[] TranscriptionHighlight { set; get; }

        public string[] SpeakerHighlight { set; get; }

        public string[] NotesHighlight { set; get; }

    }   
}
