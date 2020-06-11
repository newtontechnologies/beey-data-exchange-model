using System;

namespace Beey.DataExchangeModel.Messaging
{
    public sealed partial class FailedMessage : MessageNew
    {
        public string Reason { get; private set; }

        /// <summary>
        /// Used by deserialization. Messages are created only in subsystems.
        /// </summary>
        private FailedMessage(string subsystemName, DateTimeOffset sent, int id, int? projectId, string reason) : base(subsystemName, sent, id, projectId)
        {
            Reason = reason;
        }
    }
}
