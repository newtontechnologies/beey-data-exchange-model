using Microsoft.Extensions.Configuration;
using System;

namespace Beey.DataExchangeModel.Messaging
{
    public sealed partial class StartedMessage : Message
    {
        public IConfiguration Config { get; set; }

        /// <summary>
        /// Used by deserialization. Messages are created only in subsystems.
        /// </summary>
        private StartedMessage(string subsystemName, DateTimeOffset sent, int id, int? projectId, IConfiguration config) : base(subsystemName, sent, id, projectId)
        {
            Config = config;
        }
    }
}
