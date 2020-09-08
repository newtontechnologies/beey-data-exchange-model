using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class SpeakerIdentificationData : SubsystemData<SpeakerIdentificationData>
    {
        public string XmlSpeaker { get; set; }
        public int DiarizationMsgId { get; set; }
        public float SpeakerScore { get; set; }
        public float[] SpeakerVector { get; set; }
    }
}
