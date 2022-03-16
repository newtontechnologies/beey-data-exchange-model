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
    public abstract partial class Message : IEquatable<Message>, ITuple
    {
        public int Id { get; protected set; }
        public int? ProjectId { get; protected set; }
        public string Subsystem { get; protected set; }
        public DateTimeOffset Sent { get; protected set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageType Type => Enum.TryParse<MessageType>(this.GetType().Name.Replace("Message", ""), out var messageType)
                ? messageType
                : throw new InvalidCastException("Invalid message type.");
        /// <summary>
        /// Used by deserialization. Messages are created only in subsystems.
        /// </summary>
        protected Message(string subsystemName, DateTimeOffset sent, int id, int? projectId)
        {
            Subsystem = subsystemName;
            Sent = sent;
            Id = id;
            ProjectId = projectId;
        }

        public static System.Text.Json.JsonSerializerOptions CreateDefaultOptions()
            => new System.Text.Json.JsonSerializerOptions().AddConverters(new JsonMessageConverter());

        // TODO: channel is ignored when using System.Text.Json
        internal static ArraySegment<byte> Serialize(Message message, string channel)
        {
            var json = System.Text.Json.JsonSerializer.Serialize<Message>(message, CreateDefaultOptions());
            var bytes = Encoding.UTF8.GetBytes(json);
            return new ArraySegment<byte>(bytes);
        }

        #region Operators

        public static bool operator ==(Message first, Message second)
            => Equals(first, second);
        public static bool operator !=(Message first, Message second)
            => !Equals(first, second);

        public static Flag<Message> operator &(Message first, Message second)
            => new Flag<Message>(first) & new Flag<Message>(second);
        public static Flag<Message> operator |(Message first, Message second)
            => new Flag<Message>(first) | new Flag<Message>(second);
        public static Flag<Message> operator ~(Message message)
            => ~(new Flag<Message>(message));

        public bool Equals(Message other)
            => Equals(this, other);
        public override bool Equals(object obj)
        {
            return obj is Message msg
                ? Equals(this, msg)
                : false;
        }
        public override int GetHashCode()
            => HashCode.Combine(this.GetType(), this.Subsystem);

        #endregion Operators

        #region Switch and ITuple implementation

        int ITuple.Length => 1;
        object ITuple.this[int index] => this;

        public void Switch(params (ITuple, Action)[] cases)
            => Switch(null, cases);
        public void Switch(Action? defaultCase, params (ITuple, Action)[] cases)
        {
            foreach (var c in cases)
            {
                for (int i = 0; i < c.Item1.Length; i++)
                {
                    if (this.Equals(c.Item1[i]))
                    {
                        c.Item2();
                        return;
                    }
                }
            }

            defaultCase?.Invoke();
        }

        #endregion Switch and ITuple implementation


        /// <summary>
        /// Compares message types only.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        private static bool Equals(Message first, Message second)
        {
            if (first is null || second is null)
                return first is null && second is null;

            if (first.Subsystem == second.Subsystem)
                return first.GetType() == second.GetType();

            return false;
        }
    }
}
