using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel;

public class AggregatedListing<TItem, TAggregated> : Listing<TItem>
{
    public TAggregated TotalAggregated { get; }
    public TAggregated ListedAggregated { get; }

    public AggregatedListing(int totalCount, int listedCount,
        TAggregated totalAggregated, TAggregated listedAggregated,
        TItem[] data) : base(totalCount, listedCount, data)
    {
        TotalAggregated = totalAggregated;
        ListedAggregated = listedAggregated;
    }
}
