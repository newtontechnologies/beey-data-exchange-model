using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Transcriptions;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging.Subsystems;

public class LanguageIdentificationData : SubsystemData<LanguageIdentificationData>
{
    [JsonConverter(typeof(JsonNgEventConverter))]
    public NgEvent? NgEvent { get; set; }
}
