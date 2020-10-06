using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public class UploadSubsystemData : SubsystemData<UploadSubsystemData>
    {
        public enum DataKind
        {
            UploadedBytes,
            DisabledDataCacheReaderCreation,
            RestoreOnStreamNotSupported,
        }
        public DataKind Kind { get; set; }
        public long? FileOffset { get; internal set; }
        public int? UploadPercentage { get; internal set; }
    }
}
