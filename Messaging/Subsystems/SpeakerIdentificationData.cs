using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public class SpeakerIdentificationData : SubsystemData<SpeakerIdentificationData>
    {
        public string XmlSpeaker { get; set; }
        public int DiarizationMsgId { get; set; }
    }
}
