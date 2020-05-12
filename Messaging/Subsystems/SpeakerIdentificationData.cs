using Beey.DataExchangeModel.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class SpeakerIdentificationData : SubsystemData
    {
        public string XmlSpeaker { get; set; }
        public ASRMsg CorrespondingAsrMsg { get; set; }

        public override void Initialize(JsonData data)
        {
            throw new NotImplementedException();
        }
    }
}
