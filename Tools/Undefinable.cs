using Beey.DataExchangeModel.Serialization.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Tools
{
    /// <summary>
    /// For easier handling in custom json converters.
    /// </summary>
    public interface IUndefinable
    {
        object Value { get; set; }
        Type ValueType { get; }
        bool IsDefined { get; }
    }

    [JsonConverter(typeof(JsonUndefinableConverter))]
    public struct Undefinable<T> : IUndefinable
    {
        private static readonly Type ValueType = typeof(T);
        private bool isDefined;
        private T value;

        public bool IsDefined
        {
            get => isDefined;
            set
            {
                isDefined = value;
                if (!value)
                    Value = default;
            }
        }

        public T Value
        {
            get
            {
                if (!isDefined)
                    throw new InvalidOperationException("Undefinable value is undefined.");
                return value;
            }
            set
            {
                this.value = value;
                isDefined = true;
            }
        }

        public Undefinable(T value)
        {
            this.value = value;
            this.isDefined = true;
        }

        object IUndefinable.Value { get => Value; set => Value = (T)value; }
        Type IUndefinable.ValueType => ValueType;

        public static implicit operator Undefinable<T>(T value) => new Undefinable<T>(value);

        public static explicit operator T(Undefinable<T> undefinable) => undefinable.Value;

        public override string ToString()
        {
            if (!IsDefined || Value == null)
                return "";
            return Value.ToString();
        }
    }
}
