// just fake classes that are used instead of dependencies when POCO classes are not used on server

#if !BeeyServer
using System;

namespace Beey.DataExchangeModel
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public partial class RequiredAttribute : Attribute
    {
        public RequiredAttribute() { }
    }

    /// <summary>
    /// fake for distribution outside of server
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class KeyAttribute : Attribute
    {
        public KeyAttribute() { }
    }

    /// <summary>
    /// fake for distribution outside of server
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class ConcurrencyCheckAttribute : Attribute
    {
        public ConcurrencyCheckAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyNameAttribute : Attribute
    {
        public PropertyNameAttribute(string name) { }
    }
}

#endif