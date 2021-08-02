using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Projects
{
    public class ProjectListing<T> : Listing<T>
    {
        public int[] Uploading { get; }
        public int[] Transcoding { get; }
        public int[] Queued { get; }
        public int[] Transcribing { get; }

        public ProjectListing(Listing<T> listing, int[] uploading, int[] transcoding, int[] queued, int[] transcribing)
            : this(listing.TotalCount, listing.ListedCount, listing.List, uploading, transcoding, queued, transcribing)
        { }
        public ProjectListing(int total, int returned, T[] data, int[] uploading, int[] transcoding, int[] queued, int[] transcribing) : base(total, returned, data)
        {
            Transcoding = transcoding;
            Queued = queued;
            Transcribing = transcribing;
        }
    }
}
