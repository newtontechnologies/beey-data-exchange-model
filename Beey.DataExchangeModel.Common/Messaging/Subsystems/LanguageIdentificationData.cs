using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Transcriptions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public class LanguageIdentificationData : SubsystemData<LanguageIdentificationData>
    {
        [JsonConverter(typeof(JsonNgEventConverter))]
        public NgEvent NgEvent { get; set; }
    }
}
