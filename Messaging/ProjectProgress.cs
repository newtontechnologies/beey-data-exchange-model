using Beey.DataExchangeModel.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Messaging
{
    public partial class ProjectProgress
    {
        public ProcessState UploadState { get; set; }
        public ProcessState TranscodingState { get; set; }
        public ProcessState TranscriptionState { get; set; }
        public ProcessState DiarizationState { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    [Flags]
    public enum ProcessState
    {
        // zero value causes problems when checking for Final
        None = 1,
        Running = 2,
        Completed = 4,
        Failed = 8,
        Final = Completed | Failed
    }
}
