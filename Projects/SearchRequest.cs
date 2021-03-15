using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Projects
{
    public class SearchRequest
    {
        public int From { set; get; }

        public int Size { set; get; }

        public string Sort { set; get; }

        public string Order { set; get; }

        public string ProjectNameFullText { set; get; }

        public string TranscriptionFullText { set; get; }

        public string SpeakerFullText { set; get; }

        public DateTime? CreatedFrom { set; get; }

        public DateTime? CreatedTo { set; get; }

        public DateTime? UpdatedFrom { set; get; }

        public DateTime? UpdatedTo { set; get; }

        public double? DurationFrom { set; get; }

        public double? DurationTo { set; get; }

        public bool? MediaHasVideo { set; get; }

        public string[] Tags { set; get; }


        public SearchRequest()
        {
            Size = 10;
        }

    }
}
