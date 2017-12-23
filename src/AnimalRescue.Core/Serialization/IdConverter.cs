using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AnimalRescue.Core.Serialization
{
    public class IdConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Id<Guid>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo())
                   || typeof(Id<string>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo())
                   || typeof(Id<int>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jObject = JObject.FromObject(value);
            var idValue = jObject.GetValue("Value") as JValue;

            idValue?.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
