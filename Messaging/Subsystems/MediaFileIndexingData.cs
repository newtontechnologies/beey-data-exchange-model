using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{ 
    class MediaFileIndexingData : SubsystemData<MediaFileIndexingData>
    {
        public enum DataEnum { AudioAvailable, VideoAvailable, HeaderAvailable }
        public DataEnum Data { get; set; }
    }
}
