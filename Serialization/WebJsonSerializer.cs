using BeeyApi.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Backend.Serialization
{
    public class WebJsonSerializer : JsonSerializer
    {
        public WebJsonSerializer()
        {
            this.ContractResolver = new DoNotSerializePasswordsResolver();
            this.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            this.SerializationBinder = new DerivedTypesBinder();

            this.TypeNameHandling = TypeNameHandling.Auto;
        }

        /// <summary>
        /// just to be extra sure to ignore password fields when serilaizing
        /// </summary>
        public class DoNotSerializePasswordsResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);
                if (property.PropertyName.ToLower().Contains("password"))
                {
                    property.ShouldSerialize = (_) => false;
                }

                if (member.GetCustomAttribute(typeof(JsonIgnoreWebDeserializeAttribute)) != null)
                    property.ShouldDeserialize = (_) => false;

                if (member.GetCustomAttribute(typeof(JsonIgnoreWebAttribute)) != null)
                {
                    property.ShouldDeserialize = (_) => false;
                    property.ShouldSerialize = (_) => false;
                }

                //do not serialize ICollections (they are database foreing values..)
                var tt = member.ReflectedType;
                if (tt.IsGenericType && tt.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    property.ShouldDeserialize = (_) => false;
                    property.ShouldSerialize = (_) => false;
                }

                //type of message should be serialized if needed
                if (!typeof(Message).IsAssignableFrom(property.PropertyType))
                {
                    property.TypeNameHandling = TypeNameHandling.None;
                }

                return property;
            }

            protected override JsonContract CreateContract(Type objectType)
            {
                var contract = base.CreateContract(objectType);
                if (contract is JsonObjectContract ocontract && typeof(Message).IsAssignableFrom(ocontract.CreatedType))
                    ocontract.ItemTypeNameHandling = TypeNameHandling.None;
                else if (contract is JsonArrayContract jcontract && !typeof(Message).IsAssignableFrom(jcontract.CollectionItemType))
                    jcontract.ItemTypeNameHandling = TypeNameHandling.None;

                return contract;
            }
        }
    }
}
