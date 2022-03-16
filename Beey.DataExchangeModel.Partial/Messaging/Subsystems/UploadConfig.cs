#pragma warning disable nullable
#pragma warning disable 8618
using Beey.DataExchangeModel.Messaging.Subsystems;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public partial class UploadConfig : SubsystemConfig<UploadConfig>
    {
        public bool Stream { get; set; }

        [Obsolete("transcriptions without SavingMedia are not supported")]
        public bool SaveMedia => true;
        public int UserId { get; set; }
        public string FileName { get; set; }
        public long? TotalFileSize { get; set; }

        public UploadConfig() { }

        [Obsolete("transcriptions without SavingMedia are not supported")]
        public UploadConfig(bool saveMedia, int userId)
        {
            UserId = userId;
        }

        public UploadConfig(int userId)
        {
            UserId = userId;
        }

        protected override void AddToConfiguration(IConfigurationBuilder builder)
        {
            builder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { nameof(UserId), UserId.ToString() },
                { nameof(Stream), Stream.ToString() },
                { nameof(FileName), FileName.ToString() },
                { nameof(TotalFileSize), TotalFileSize.ToString() }
            });
        }
    }
}
