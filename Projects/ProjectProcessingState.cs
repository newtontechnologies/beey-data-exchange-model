using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Projects
{
    public enum ProjectProcessingState
    {
        /// <summary>
        /// Project is empty - after creation.
        /// </summary>
        None,

        /// <summary>
        /// Project is being transcoded.
        /// </summary>
        TranscodingOnly,

        /// <summary>
        /// Project is in a queue and will be transcribed. Transcoding is running or already finished.
        /// </summary>
        Queued,

        /// <summary>
        /// Transcription on project will start as soon as it is ready.
        /// </summary>
        ScheduledForTranscription,

        /// <summary>
        /// Project is being transcribed.
        /// </summary>
        Transcribing,

        /// <summary>
        /// Project processing was canceled by user.
        /// </summary>
        Canceled,

        /// <summary>
        /// Project was processed successfuly.
        /// </summary>
        Completed,

        /// <summary>
        /// There was an error during processing of the project.
        /// </summary>
        Failed
    }
}
