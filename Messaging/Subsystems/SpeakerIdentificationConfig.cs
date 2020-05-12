using Microsoft.Extensions.Configuration;
using System;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class SpeakerIdentificationConfig : SubsystemConfig
    {
        public string Language { get; internal set; }
        public string VoiceprintVersion { get; internal set; }
        public int SufficientSpeakerDuration { get; internal set; }

        protected override void AddToConfiguration(IConfigurationBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}
