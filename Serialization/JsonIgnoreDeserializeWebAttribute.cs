using System;

namespace Backend.Serialization
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class JsonIgnoreWebDeserializeAttribute :Attribute
    {
    }
}