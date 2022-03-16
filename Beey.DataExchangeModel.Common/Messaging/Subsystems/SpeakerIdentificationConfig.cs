using Beey.DataExchangeModel.Voiceprints;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public class SpeakerIdentificationConfig : SubsystemConfig<SpeakerIdentificationConfig>
    {
        public string Language { get; set; }
        public string VoiceprintVersion { get; set; }
        public int SufficientSpeakerDuration { get; set; }
        public VoiceprintModelInfo[] VoiceprintModels { get; set; }

        protected override void AddToConfiguration(IConfigurationBuilder builder)
        {
            var dict = new Dictionary<string, string>()
            {
                { nameof(Language), Language },
                { nameof(VoiceprintVersion), VoiceprintVersion },
                { nameof(SufficientSpeakerDuration), SufficientSpeakerDuration.ToString() }
            };

            if (VoiceprintModels != null)
            {
                for (int i = 0; i < VoiceprintModels.Length; i++)
                {
                    dict.Add($"{nameof(VoiceprintModels)}:{i}:{nameof(VoiceprintModelInfo.Hash)}", VoiceprintModels[i].Hash);
                    dict.Add($"{nameof(VoiceprintModels)}:{i}:{nameof(VoiceprintModelInfo.AcceptanceThreshold)}", VoiceprintModels[i].AcceptanceThreshold.ToString(CultureInfo.InvariantCulture));
                }
            }
            builder.AddInMemoryCollection(dict);
        }
    }
}
