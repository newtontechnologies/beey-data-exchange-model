using System;

namespace Beey.DataExchangeModel.Messaging
{
    public sealed partial class CompletedMessage : MessageNew
    {
        /// <summary>
        /// Used by deserialization. Messages are created only in subsystems.
        /// </summary>
        private CompletedMessage(string subsystemName, DateTimeOffset sent, int id, int? projectId) : base(subsystemName, sent, id, projectId)
        {
        }
    }
}
