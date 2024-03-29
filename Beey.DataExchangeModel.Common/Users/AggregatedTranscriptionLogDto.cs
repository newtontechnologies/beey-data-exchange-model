﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Users;

public class AggregatedTranscriptionLogDto
{
    public int Year { get; }
    public int Month { get; }
    public decimal Minutes { get; }

    public AggregatedTranscriptionLogDto(int year, int month, decimal minutes)
    {
        Year = year;
        Month = month;
        Minutes = minutes;
    }
}
