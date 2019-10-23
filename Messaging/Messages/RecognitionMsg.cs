using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Messaging.Messages
{
    class RecognitionMsg : Message<RecognitionMsg.MessageKind>
    {
        [Flags]
        public enum MessageKind
        {
            Started = 1,
            Finished = 2,
            Cancelled = 4,
            IsTerminated = Finished | Cancelled,
        }
    }
}
