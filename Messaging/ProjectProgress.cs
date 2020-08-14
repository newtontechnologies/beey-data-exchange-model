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
        public ProcessState MediaIdentificationState { get; set; }
        public ProcessState TranscodingState { get; set; }
        public ProcessState TranscodingVideoState { get; set; }
        public ProcessState TranscodingAudioState { get; set; }
        public ProcessState FileIndexingState { get; set; }
        public ProcessState FilePackagingState { get; set; }
        public ProcessState RecognitionState { get; set; }
        public ProcessState DiarizationState { get; set; }
        public ProcessState SpeakerIdentificationState { get; set; }
        public ProcessState PPCState { get; set; }
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
        Finished = Completed | Failed
    }
}
