using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Transcriptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class DiarizationData : SubsystemData<DiarizationData>
    {
        public bool IsLookahead { get; set; }
        [JsonConverter(typeof(JsonNgEventConverter))]
        public NgEvent NgEvent { get; set; }
    }
}
