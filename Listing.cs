using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel
{
    public partial class Listing<T>
    {
        public int TotalCount { get; set; }
        public int ListedCount { get; set; }

        public T[] List { get; set; }

        public Listing(int totalCount, int listedCount, T[] data)
        {
            TotalCount = totalCount;
            ListedCount = listedCount;
            List = data;
        }
    }

    public static class Listing
    {
        public static Listing<T> Create<T>(int totalCount, int listedCount, T[] data)
        {
            return new Listing<T>(totalCount, listedCount, data);
        }
    }
}
