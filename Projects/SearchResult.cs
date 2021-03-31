using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Projects
{   
    public class SearchResult
    {
        public int ProjectId { set; get; }

        public string ProjectName { set; get; }

        public string[] Tags { set; get; }

        public TimeSpan Length { get; set; }

        public DateTime? Created { set; get; }

        public DateTime? Updated { set; get; }

        public string[] ProjectNameHighlight { set; get; }

        public string[] TranscriptionHighlight { set; get; }

        public string[] SpeakerHighlight { set; get; }

        public string[] NotesHighlight { set; get; }

    }
}
