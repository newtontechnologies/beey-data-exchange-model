using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Tools;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Messaging
{
    public enum MessageType
    {
        /// <summary>
        /// Started message, sent when subsystem is ready to receive messages
        /// Also, send to subsystem to mark end of subsystem generator read messages
        /// </summary>
        Started,
        /// <summary>
        /// Output data message from subsystem
        /// </summary>
        Progress,
        /// <summary>
        /// Subsystem exited with exception
        /// </summary>
        Failed,
        /// <summary>
        /// Subsystem exited without error 
        /// </summary>
        Completed,
        /// <summary>
        /// Send by chain to notify all subsystem about status change of subsystem
        /// Each change of status generates status message. (there is only one change in status in each message)
        /// </summary>
        ChainStatus,
        /// <summary>
        /// Chain uses this to interact with subsystems. Propagates external commands to chain (start transcription, user invoked chain cancellation )
        /// </summary>
        ChainCommand,
        /// <summary>
        /// Subsystem control mechanism detected error in subsystem behavior.
        /// This indicates unrecoverable error and will trigger forecefull subsystem termination.
        /// </summary>
        Panic
    }
}
