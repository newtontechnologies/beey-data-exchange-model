using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeyApi.Messaging.Messages
{
    public partial class TranscriptionMsg : Message<TranscriptionMsg.MessageKind>
    {
        [Flags]
        public enum MessageKind
        {
            Started,
            Completed,
            Failed,
            Interrupted,
            IsTerminated = Completed | Failed | Interrupted,
        }

        public string Language { get; internal set; }
        public TimeSpan? Transcribed { get; internal set; }
    }
}
