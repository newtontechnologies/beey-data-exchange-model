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
        /// Project is being processed.
        /// </summary>
        Processing,

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
