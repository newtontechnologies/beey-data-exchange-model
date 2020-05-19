#pragma warning disable nullable
#pragma warning disable 8618
using Beey.DataExchangeModel.Messaging.Subsystems;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public partial class TranscriptionConfig : SubsystemConfig<TranscriptionConfig>
    {
        public bool SaveTrsx { get; }
        public string Language { get; }
        public bool WithPPC { get; }
        public int UserId { get; }

        public TranscriptionConfig() { }
        public TranscriptionConfig(bool saveTrsx, string language, bool withPPC, int userId)
        {
            SaveTrsx = saveTrsx;
            Language = language;
            WithPPC = withPPC;
            UserId = userId;
        }

        protected override void AddToConfiguration(IConfigurationBuilder builder)
        {
            builder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { nameof(SaveTrsx), SaveTrsx.ToString() },
                { nameof(Language), Language },
                { nameof(WithPPC), WithPPC.ToString() },
                { nameof(UserId), UserId.ToString() }
            });
        }
    }
}
