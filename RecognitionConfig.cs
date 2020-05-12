#pragma warning disable nullable
#pragma warning disable 8618
using Beey.DataExchangeModel.Messaging.Subsystems;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Beey.DataExchangeModel
{
    public partial class RecognitionConfig : SubsystemConfig
    {
        public bool SaveTrsx { get; }
        public string Language { get; }
        public bool WithPPC { get; }
        public int UserID { get; }

        public RecognitionConfig() { }
        public RecognitionConfig(bool saveTrsx, string language, bool withPPC, int userId)
        {
            SaveTrsx = saveTrsx;
            Language = language;
            WithPPC = withPPC;
            UserID = userId;
        }

        protected override void AddToConfiguration(IConfigurationBuilder builder)
        {
            builder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { nameof(SaveTrsx), SaveTrsx.ToString() },
                { nameof(Language), Language },
                { nameof(WithPPC), WithPPC.ToString() },
                { nameof(UserID), UserID.ToString() }
            });
        }
    }
}
