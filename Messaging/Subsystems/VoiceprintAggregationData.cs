using Beey.DataExchangeModel.Transcriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public class VoiceprintAggregationData : SubsystemData<VoiceprintAggregationData>
    {
        public float[]? Voiceprint { get; set; }
        public NgSpeakerEvent Speaker { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
