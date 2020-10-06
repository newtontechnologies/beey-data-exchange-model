using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public class SpeakerIdentificationConfig : SubsystemConfig<SpeakerIdentificationConfig>
    {
        public string Language { get; set; }
        public string VoiceprintVersion { get; set; }
        public int SufficientSpeakerDuration { get; set; }

        protected override void AddToConfiguration(IConfigurationBuilder builder)
        {
            builder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { nameof(Language), Language },
                { nameof(VoiceprintVersion), VoiceprintVersion },
                { nameof(SufficientSpeakerDuration), SufficientSpeakerDuration.ToString() }
            });
        }
    }
}
