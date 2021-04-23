﻿#pragma warning disable nullable
#pragma warning disable 8618
using Beey.DataExchangeModel.Messaging.Subsystems;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public partial class UploadConfig : SubsystemConfig<UploadConfig>
    {
        public bool Stream { get; set; }
        public int UserId { get; set; }

        public UploadConfig() { }
        public UploadConfig(int userId)
        {          
            UserId = userId;
        }

        protected override void AddToConfiguration(IConfigurationBuilder builder)
        {
            builder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { nameof(UserId), UserId.ToString() },
                { nameof(Stream), Stream.ToString() }
            });
        }
    }
}
