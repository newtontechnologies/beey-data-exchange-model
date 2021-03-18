﻿using System;
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

        public string[] Name { set; get; }

        public string[] Text { set; get; }

        public string[] Speaker { set; get; }

        public string[] Notes { set; get; }
    }
}
