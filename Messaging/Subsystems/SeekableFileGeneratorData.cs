using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{ 
    class SeekableFileGeneratorData : SubsystemData<SeekableFileGeneratorData>
    {
        public enum DataEnum { AudioAvailable, VideoAvailable }

        public DataEnum Data { get; set; }
        public override void Initialize(JsonData data, JsonSerializerOptions options = null)
        {
            Data = Enum.Parse<DataEnum>(data.JsonElement.GetProperty(nameof(Data)).GetString());
        }
    }
}
