﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Messaging.Messages
{
    public partial class RecordingConversionMsg : Message<RecordingConversionMsg.MessageKind>
    {
        public enum MessageKind
        {
            Started,
            Progress,
            Completed,
            Failed,
            StreamingConversionFailed,
            AudioAvailable,
            VideoAvailable,
        }

        public TimeSpan MediaElapsed { get; set; }
    }
}
