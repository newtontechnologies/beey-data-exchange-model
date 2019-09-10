using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Messaging
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public abstract class Message : IEquatable<Message>
    {
        public string Type => this.GetType().Name;
        private static int MessageIdCounter = 0;

        public DateTimeOffset Sent { get; }

        public Message()
        {
            Sent = DateTimeOffset.Now;
            Id = Interlocked.Increment(ref MessageIdCounter);
        }

        /// <summary>
        /// Most messages are send as direct results on actions on some project
        /// If the message is not project related it could be null
        /// </summary>
        public int? ProjectID { get; set; }
        /// <summary>
        /// Each message have unique ID
        /// Client can get message with same id through multiple channels, and should react only on first message
        /// </summary>
        public int Id { get; }

        internal static Message Deserialize(byte[] buffer, int count)
        {
            var data = Encoding.UTF8.GetString(buffer, 0, count);
            return JsonConvert.DeserializeObject<Message>(data);
        }

        internal static ArraySegment<byte> Serialize(Message data, string channel)
        {
            var jo = JObject.FromObject(data);
            if (!string.IsNullOrEmpty(channel))
                jo["Channel"] = channel;

            var jdata = jo.ToString();
            var sdata = Encoding.UTF8.GetBytes(jdata);
            
            return new ArraySegment<byte>(sdata);
        }

        public bool Equals(Message other) => this.Id == other.Id;
    }

    public abstract class Message<T> : Message where T : Enum
    {
        public Message()
        {

        }

        [JsonConverter(typeof(StringEnumConverter))]
        public T Kind { get; set; }
    }
}
