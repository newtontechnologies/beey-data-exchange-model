using Beey.DataExchangeModel.Tools;
using System;

namespace Beey.DataExchangeModel.Messaging
{
    public abstract partial class MessageNew : IEquatable<MessageNew>
    {
        public int Id { get; protected set; }
        public int? ProjectId { get; protected set; }
        public string Subsystem { get; protected set; }
        public DateTimeOffset Sent { get; protected set; }
        public string Type { get => this.GetType().Name.Replace("Message", ""); }

        /// <summary>
        /// Used by deserialization. Messages are created only in subsystems.
        /// </summary>
        protected MessageNew(string subsystemName, DateTimeOffset sent, int id, int? projectId)
        {
            Subsystem = subsystemName;
            Sent = sent;
            Id = id;
            ProjectId = projectId;
        }

        public static bool operator ==(MessageNew first, MessageNew second)
            => Equals(first, second);
        public static bool operator !=(MessageNew first, MessageNew second)
            => !Equals(first, second);

        public static Flag<MessageNew> operator &(MessageNew first, MessageNew second)
            => new Flag<MessageNew>(first) & new Flag<MessageNew>(second);
        public static Flag<MessageNew> operator |(MessageNew first, MessageNew second)
            => new Flag<MessageNew>(first) | new Flag<MessageNew>(second);
        public static Flag<MessageNew> operator ~(MessageNew message)
            => ~(new Flag<MessageNew>(message));

        public bool Equals(MessageNew other)
            => Equals(this, other);
        public override bool Equals(object obj)
        {
            return obj is MessageNew msg
                ? Equals(this, msg)
                : false;
        }
        public override int GetHashCode()
            => HashCode.Combine(this.GetType(), this.Subsystem);

        public TResult Switch<TResult>(params (MessageNew, Func<TResult>)[] cases)
            => Switch(default, cases);
        public TResult Switch<TResult>(Func<TResult> defaultCase, params (MessageNew, Func<TResult>)[] cases)
        {
            foreach (var c in cases)
            {
                if (this == c.Item1)
                {
                    return c.Item2();
                }
            }

            return defaultCase != null ? defaultCase() : default;
        }

        public void Switch(params (MessageNew, Action)[] cases)
            => Switch(default, cases);
        public void Switch(Action defaultCase, params (MessageNew, Action)[] cases)
        {
            foreach (var c in cases)
            {
                if (this == c.Item1)
                {
                    c.Item2();
                    return;
                }
            }

            if (defaultCase != null) { defaultCase(); }
        }

        /// <summary>
        /// Compares message types only.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        private static bool Equals(MessageNew first, MessageNew second)
        {
            if (first is null || second is null)
                return false;

            if (first.Subsystem == second.Subsystem)
                return first.GetType() == second.GetType();

            return false;
        }
    }
}
