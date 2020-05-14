using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class UploadSubsystemData : SubsystemData<UploadSubsystemData>
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
        public override void Initialize(JsonData data)
        {
            Kind = Enum.Parse<DataKind>(data.JsonElement.GetProperty(nameof(Kind)).GetRawText());
            if (data.JsonElement.TryGetProperty(nameof(FileOffset), out var fileOffsetProp))
                FileOffset = fileOffsetProp.ValueKind == System.Text.Json.JsonValueKind.Number
                    ? (long?)fileOffsetProp.GetInt64()
                    : null;
            if (data.JsonElement.TryGetProperty(nameof(UploadPercentage), out var uploadPercentageProp))
                UploadPercentage = uploadPercentageProp.ValueKind == System.Text.Json.JsonValueKind.Number
                    ? (int?)uploadPercentageProp.GetInt32()
                    : null;
        }
    }
}
