using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Messaging.Messages2
{
    public class MessageKindConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.BaseType.IsGenericType
                && objectType.BaseType.GetGenericTypeDefinition() == typeof(MessageKind<,>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            return objectType.GetMethod("Parse").Invoke(null, new object[] { obj.ToString() });
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
