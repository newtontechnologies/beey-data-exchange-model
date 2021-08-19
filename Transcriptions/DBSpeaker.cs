#if BeeyServer
using Nest;
#endif
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TranscriptionCore;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Transcriptions
{
    public partial class DBSpeaker
    {
        // With other values, search is broken probably because of ES analyzers.
        public const string GlobalId = "";
        public string Id { get; set; }
        private Speaker _speaker;

        [JsonIgnore]
        public Speaker Speaker { get => _speaker; set => _speaker = value; }

        public string XMLSpeaker
        {
            get => _speaker.Serialize().ToString();
            set => _speaker = new Speaker(XElement.Parse(value));
        }

        // NOTE: This must be string for ES context suggester to work.
        // TODO: This should be removed, but speakers in all elasticsearch instances must be re-indexed for this to work.
        [PropertyName("userId")]
        public string WorkspaceId { get; set; } = GlobalId;

        public bool? Deleted { set; get; }
    }
}
