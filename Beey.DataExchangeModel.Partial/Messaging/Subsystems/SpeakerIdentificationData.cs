using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

#nullable enable 
namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public class SpeakerIdentificationData : SubsystemData<SpeakerIdentificationData>
    {
        public string? XmlSpeaker { get; set; }
        public TimeSpan? SampleStart { get; set; }
        public TimeSpan? SampleEnd { get; set; }
        public float? Score { get; set; }
        public string? Voiceprint { get; set; }
        public SpeakerIdentificationConfig? Config { get; set; }
    }
}
