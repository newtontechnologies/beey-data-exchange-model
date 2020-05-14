#pragma warning disable nullable
#pragma warning disable 8618
using Beey.DataExchangeModel.Messaging.Subsystems;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Beey.DataExchangeModel
{
    public partial class UploadConfig : SubsystemConfig<UploadConfig>
    {
        public bool SaveMedia { get; }
        public int UserID { get; }

        public UploadConfig() { }
        public UploadConfig(bool saveMedia, int userId)
        {          
            SaveMedia = saveMedia;
            UserID = userId;
        }

        protected override void AddToConfiguration(IConfigurationBuilder builder)
        {
            builder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { nameof(SaveMedia), SaveMedia.ToString() },
                { nameof(UserID), UserID.ToString() }
            });
        }
    }
}
