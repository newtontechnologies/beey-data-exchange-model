using System;

namespace Beey.DataExchangeModel.Serialization
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class JsonIgnoreWebDeserializeAttribute :Attribute
    {
    }
}