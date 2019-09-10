using Beey.DataExchangeModel.Messaging;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8618,8603,8625
namespace Beey.DataExchangeModel.Serialization
{
    /// <summary>
    /// There have to be custom binder to limit type serialization
    /// fe: You can set readonly flag on file without binder..
    /// https://www.alphabot.com/security/blog/2017/net/How-to-configure-Json.NET-to-create-a-vulnerable-web-API.html
    /// </summary>
    public class DerivedTypesBinder : ISerializationBinder
    {
        static readonly DefaultSerializationBinder _binder = new DefaultSerializationBinder();
        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            //do not write type information ever
            assemblyName = null;
            typeName = null;

            //except when it si message
            if (typeof(Message).IsAssignableFrom(serializedType))
                _binder.BindToName(serializedType, out assemblyName, out typeName);


        }

        public Type BindToType(string assemblyName, string typeName)
        {
            var type = _binder.BindToType(assemblyName, typeName);

            //only return types when we are deserilizing message
            if(typeof(Message).IsAssignableFrom(type))
                return type;

            return null;
        }
    }
}
