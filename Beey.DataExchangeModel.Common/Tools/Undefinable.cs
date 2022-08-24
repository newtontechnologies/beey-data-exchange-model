using Beey.DataExchangeModel.Serialization.JsonConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Tools;

[JsonConverter(typeof(JsonUndefinableConverter))]
public struct Undefinable<T>
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

    public static implicit operator Undefinable<T>(T value) => new Undefinable<T>(value);

    public static explicit operator T(Undefinable<T> undefinable) => undefinable.Value;

    public override string ToString()
    {
        if (!IsDefined || Value == null)
            return "";
        return Value.ToString() ?? "";
    }
}
