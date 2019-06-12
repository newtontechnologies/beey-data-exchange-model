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

        public Listing(int total, int returned, T[] data)
        {
            TotalCount = total;
            ListedCount = returned;
            List = data;
        }
    }

    public static class Listing
    {
        public static Listing<T> Create<T>(int total, int returned, T[] data)
        {
            return new Listing<T>(total, returned, data);
        }
    }
}
