#pragma warning disable nullable
#pragma warning disable 8618
using Beey.DataExchangeModel.Messaging.Subsystems;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public class TranscriptionConfig : SubsystemConfig<TranscriptionConfig>
    {
        public bool SaveTrsx { get; set; }
        public string Language { get; set; }
        public bool WithPPC { get; set; }
        public bool WithVAD { get; set; }
        public bool WithPunctuation { get; set; }
        public int UserId { get; set; }

        public bool TrialTranscription { get; set; } = false;

        public TranscriptionConfig() { }
        public TranscriptionConfig(bool saveTrsx, string language, bool withPPC, bool withVAD, bool withPunctuation, int userId)
        {
            SaveTrsx = saveTrsx;
            Language = language;
            WithPPC = withPPC;
            WithVAD = withVAD;
            WithPunctuation = withPunctuation;
            UserId = userId;
        }

        protected override void AddToConfiguration(IConfigurationBuilder builder)
        {
            builder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { nameof(SaveTrsx), SaveTrsx.ToString() },
                { nameof(Language), Language },
                { nameof(WithPPC), WithPPC.ToString() },
                { nameof(WithVAD), WithVAD.ToString() },
                { nameof(UserId), UserId.ToString() },
                { nameof(WithPunctuation), WithPunctuation.ToString() },
            });
        }
    }
}
