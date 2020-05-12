using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{ 
    class SeekableFileGeneratorData : SubsystemData
    {
        public enum DataEnum { AudioAvailable, VideoAvailable }

        public DataEnum Data { get; set; }
        public override void Initialize(JsonData data)
        {
            Data = Enum.Parse<DataEnum>(data.JsonElement.GetProperty(nameof(Data)).GetString());
        }
    }
}
