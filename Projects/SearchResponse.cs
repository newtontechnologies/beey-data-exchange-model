using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Projects
{
    public class SearchResponse
    {
        public SearchResult[] Results { set; get; }
    }

    public class SearchResult
    {
        public int ProjectId { set; get; }

        public string[] Name { set; get; }

        public string[] Text { set; get; }
    }
}
