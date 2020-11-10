// just fake classes that are used instead of dependencies when POCO classes are not used on server

#if !BeeyServer
namespace System.ComponentModel.DataAnnotations.Schema
{
    /// <summary>
    /// fake for distribution outside of server
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public partial class NotMappedAttribute : Attribute
    {
        public NotMappedAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute();
        public ColumnAttribute(string name);
    }
}

namespace System.ComponentModel.DataAnnotations
{
  
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
}

#endif