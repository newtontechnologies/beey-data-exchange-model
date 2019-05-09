using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeyApi.Messaging.Messages
{
    public partial class FileUploadMsg : Message<FileUploadMsg.MessageKind>
    {
        public long? FileOffset { get; internal set; }

        [Flags]
        public enum MessageKind
        {
            Started,
            Completed,
            Failed,
            IsTerminated = Completed | Failed,
            UploadedBytes,
        }
    }
}
