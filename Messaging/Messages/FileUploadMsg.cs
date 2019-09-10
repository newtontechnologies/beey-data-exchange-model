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
        public UploadConfig Config { get; set; }

        [Flags]
        public enum MessageKind
        {
            Started,
            Completed,
            Failed,
            IsTerminated = Completed | Failed,
            UploadedBytes,
        }

        public class UploadConfig
        {
            public UploadConfig(bool transcribe, bool saveMedia, bool saveTrsx)
            {
                Transcribe = transcribe;
                SaveMedia = saveMedia;
                SaveTrsx = saveTrsx;
            }

            public bool Transcribe { set; get; }
            public bool SaveTrsx { set; get; }
            public bool SaveMedia { set; get; }
        }
    }
}
