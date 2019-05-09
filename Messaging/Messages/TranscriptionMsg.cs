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

        /// <summary>
        /// ppc can mark this message to not processit multiple times
        /// </summary>
        [JsonIgnore]
        public bool FromPpc { get; set; }
        public string Language { get; internal set; }
    }
}
