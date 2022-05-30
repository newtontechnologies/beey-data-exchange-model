using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Tools;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Messaging
{
    public abstract record Message(int Id, int[] Index, int? ProjectId, string Subsystem, DateTimeOffset Sent)
    {

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public abstract MessageType Type { get; }

        public static System.Text.Json.JsonSerializerOptions CreateDefaultOptions()
            => new System.Text.Json.JsonSerializerOptions().AddConverters(new JsonMessageConverter());

        // TODO: channel is ignored when using System.Text.Json
        public static ArraySegment<byte> Serialize(Message message, string channel)
        {
            var json = System.Text.Json.JsonSerializer.Serialize<Message>(message, CreateDefaultOptions());
            var bytes = Encoding.UTF8.GetBytes(json);
            return new ArraySegment<byte>(bytes);
        }

        #region Operators

        public static Flag<Message> operator &(Message first, Message second)
            => new Flag<Message>(first) & new Flag<Message>(second);
        public static Flag<Message> operator |(Message first, Message second)
            => new Flag<Message>(first) | new Flag<Message>(second);
        public static Flag<Message> operator ~(Message message)
            => ~(new Flag<Message>(message));

        #endregion Operators
    }
}
