using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems;

public class UploadSubsystemData : SubsystemData<UploadSubsystemData>
{
    public enum DataKind
    {
        UploadedBytes,
        DisabledDataCacheReaderCreation,
        RestoreOnStreamNotSupported,
    }
    public DataKind Kind { get; set; }
    public long? FileOffset { get; set; }
    public int? UploadPercentage { get; set; }
}
