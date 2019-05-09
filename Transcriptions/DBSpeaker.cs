using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TranscriptionCore;

namespace BeeyApi.POCO.Transcriptions
{
    public partial class DBSpeaker
    {
        public string Id { get; set; }
        private Speaker _speaker;

        [JsonIgnore]
        public Speaker Speaker { get => _speaker; set => _speaker = value; }

        public string XMLSpeaker
        {
            get => _speaker.Serialize().ToString();
            set => _speaker = new Speaker(XElement.Parse(value));
        }

        //null for global speaker
        public int? UserId { get; set; } = null;
    }
}
