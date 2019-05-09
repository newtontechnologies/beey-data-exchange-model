using BeeyApi.POCO.Transcriptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeyApi.Messaging.Messages
{
    public partial class ASRMsg : Message<ASRMsg.MessageKind>
    {
        public NgEvent Event { get; set; }
        public enum MessageKind
        {
            Phrase,
            Speaker,
            SpeakerRecovery,
        }

        /// <summary>
        /// ppc can mark this message to not processit multiple times
        /// </summary>
        [JsonIgnore]
        public bool FromPpc { get; set; }
    }
}
