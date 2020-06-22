using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Tools;
using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Messaging
{
    public enum MessageType { Started, Progress, Failed, Completed }
    public abstract partial class Message : IEquatable<Message>, ITuple
    {
        public int Id { get; protected set; }
        public int? ProjectId { get; protected set; }
        public string Subsystem { get; protected set; }
        public DateTimeOffset Sent { get; protected set; }
        public string Type { get => this.GetType().Name.Replace("Message", ""); }
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
        public void Switch(Action defaultCase, params (ITuple, Action)[] cases)
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

        public Task SwitchAsync(params (ITuple, Func<Task>)[] cases)
            => SwitchAsync(null, cases);
        public Task SwitchAsync(Func<Task> defaultCase, params (ITuple, Func<Task>)[] cases)
        {
            foreach (var c in cases)
            {
                for (int i = 0; i < c.Item1.Length; i++)
                {
                    if (this.Equals(c.Item1[i]))
                    {
                        return c.Item2();
                    }
                }
            }

            return defaultCase != null ? defaultCase() : Task.CompletedTask;
        }

        public TResult Switch<TResult>(params (ITuple, Func<TResult>)[] cases)
            => Switch(null, cases);
        public TResult Switch<TResult>(TResult defaultValue, params (ITuple, Func<TResult>)[] cases)
            => Switch(() => defaultValue, cases);
        public TResult Switch<TResult>(Func<TResult> defaultCase, params (ITuple, Func<TResult>)[] cases)
        {
            foreach (var c in cases)
            {
                for (int i = 0; i < c.Item1.Length; i++)
                {
                    if (this.Equals(c.Item1[i]))
                    {
                        return c.Item2();
                    }
                }
            }

            return defaultCase != null ? defaultCase() : default;
        }

        public Task<TResult> SwitchAsync<TResult>(params (ITuple, Func<Task<TResult>>)[] cases)
            => SwitchAsync(null, cases);
        public Task<TResult> SwitchAsync<TResult>(TResult defaultValue, params (ITuple, Func<Task<TResult>>)[] cases)
            => SwitchAsync(() => Task.FromResult(defaultValue), cases);
        public Task<TResult> SwitchAsync<TResult>(Func<Task<TResult>> defaultCase, params (ITuple, Func<Task<TResult>>)[] cases)
        {
            foreach (var c in cases)
            {
                for (int i = 0; i < c.Item1.Length; i++)
                {
                    if (this.Equals(c.Item1[i]))
                    {
                        return c.Item2();
                    }
                }
            }

            return defaultCase != null ? defaultCase() : Task.FromResult<TResult>(default);
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
