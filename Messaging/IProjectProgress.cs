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
    public enum ProcessState { None, Running, Completed, Failed }
}
