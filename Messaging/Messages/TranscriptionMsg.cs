using Beey.DataExchangeModel.Messaging.Messages2;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Messaging.Messages
{
    public partial class TranscriptionMsg : Message<TranscriptionMsgKind>
    {
        [Flags]
        public enum MessageKind
        {
            Started = 1,
            Completed = 2,
            Failed = 4,
            Interrupted = 8,
            IsTerminated = Completed | Failed | Interrupted,
        }

        public string Language { get; internal set; }
        public TimeSpan? Transcribed { get; internal set; }
    }
    
}
