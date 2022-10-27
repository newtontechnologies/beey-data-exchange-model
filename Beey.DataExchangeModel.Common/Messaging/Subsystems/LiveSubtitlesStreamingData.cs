using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beey.DataExchangeModel.Messaging.Subsystems;

namespace Beey.DataExchangeModel.Common.Messaging.Subsystems;

public class LiveSubtitlesStreamingData : SubsystemData<LiveSubtitlesStreamingData>
{
    public string Text { get; set; }
    public double Begin { get; set; }
    public double End { get; set; }
}
