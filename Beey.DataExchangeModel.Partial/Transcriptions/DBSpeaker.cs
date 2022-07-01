using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
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

        public string TeamId { get; set; } = GlobalId;

        public bool? Deleted { set; get; }
    }
}
