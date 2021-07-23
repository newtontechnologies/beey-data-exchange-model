using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Projects
{
    public class ProjectListing<T> : Listing<T>
    {
        public int[] Transcoding { get; set; }
        public int[] Queued { get; set; }
        public int[] Transcribing { get; set; }

        public ProjectListing(Listing<T> listing, int[] transcoding, int[] queued, int[] transcribing)
            : this(listing.TotalCount, listing.ListedCount, listing.List, transcoding, queued, transcribing)
        { }
        public ProjectListing(int total, int returned, T[] data, int[] transcoding, int[] queued, int[] transcribing) : base(total, returned, data)
        {
            Transcoding = transcoding;
            Queued = queued;
            Transcribing = transcribing;
        }
    }
}
