using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Messaging
{
    public interface IProjectProgress
    {
        int ProjectId { get; }
        IEnumerable<Message> MessageHistory { get; }
        ProcessState UploadState { get; }
        ProcessState TranscodingState { get; }
        ProcessState TranscriptionState { get; }
        ProcessState DiarizationState { get; }

        System.Threading.Tasks.Task StopAsync();
    }
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
