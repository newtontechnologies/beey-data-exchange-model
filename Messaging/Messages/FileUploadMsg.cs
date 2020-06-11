using Beey.DataExchangeModel.Messaging.Subsystems;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Messaging.Messages
{
    public partial class FileUploadMsg : Message<FileUploadMsg.MessageKind>
    {
        public long? FileOffset { get; internal set; }
        public int? UploadPercentage { get; internal set; }
        public UploadConfig Config { get; set; }

        [Flags]
        public enum MessageKind
        {
            Started = 1,
            Completed = 2,
            Failed = 4,
            UploadedBytes = 8,
            IsTerminated = Completed | Failed,

            DisabledDataCacheReaderCreation = 0x10,
            RestoreOnStreamNotSupported = 0x20,
        }
    }
}
