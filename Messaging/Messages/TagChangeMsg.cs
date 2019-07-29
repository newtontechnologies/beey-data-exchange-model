using Beey.DataExchangeModel.Transcriptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
namespace Beey.DataExchangeModel.Messaging.Messages
{
    public partial class TagChangeMsg : Message<TagChangeMsg.MessageKind>
    {
        public string Tag { get; set; }
        public enum MessageKind
        {
            Added,
            Removed,
        }
    }
}
