using Beey.DataExchangeModel.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Serialization.JsonConverters
{
    public class JsonUndefinableConverter : JsonConverter
    {
        private static readonly Type TypeOfIUndefinable = typeof(IUndefinable);

        public override bool CanConvert(Type objectType) => TypeOfIUndefinable.IsAssignableFrom(objectType);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (existingValue == null)
                existingValue = Activator.CreateInstance(objectType);

            if (reader.TokenType != JsonToken.Undefined)
            {
                var undefinable = (IUndefinable)existingValue;
                undefinable.Value = serializer.Deserialize(reader, undefinable.ValueType);
            }

            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var undefinable = (IUndefinable)value;
            if (!undefinable.IsDefined)
                writer.WriteUndefined();
            else
                serializer.Serialize(writer, undefinable.Value);
        }
    }
}
