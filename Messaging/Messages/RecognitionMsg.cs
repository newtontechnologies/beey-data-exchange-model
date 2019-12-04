using Beey.DataExchangeModel.Messaging.Messages2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Messaging.Messages
{
    class RecognitionMsg : Message<RecognitionMsgKind>
    {
        [Flags]
        public enum MessageKind
        {
            Started = 1,
            Completed = 2,
            Cancelled = 4,
            IsTerminated = Completed | Cancelled,
        }
    }
    
}
