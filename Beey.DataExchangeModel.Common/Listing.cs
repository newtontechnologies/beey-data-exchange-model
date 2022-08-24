﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel;

public class Listing<T>
{
    public int TotalCount { get; set; }
    public int ListedCount { get; set; }

    public T[] List { get; set; }

    public Listing(int totalCount, int listedCount, T[] list)
    {
        TotalCount = totalCount;
        ListedCount = listedCount;
        List = list;
    }
}

public static class Listing
{
    public static Listing<T> Create<T>(int totalCount, int listedCount, T[] list)
    {
        return new Listing<T>(totalCount, listedCount, list);
    }
}
