using System;

namespace Beey.DataExchangeModel.Messaging
{
    public sealed partial class ProgressMessage : Message
    {
        public JsonData Data { get; private set; }

        /// <summary>
        /// Used by deserialization. Messages are created only in subsystems.
        /// </summary>
        private ProgressMessage(string subsystemName, DateTimeOffset sent, int id, int? projectId, JsonData data) : base(subsystemName, sent, id, projectId)
        {
            Data = data;
        }
    }
}
