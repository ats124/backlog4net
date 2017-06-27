using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Backlog4net.Internal.Json
{
    internal class MultiTypeConverter<T> : JsonConverter
    {
        public string Key { get; private set; }
        public IDictionary<string, Type> Mappings { get; private set; }
        public Type DefaultType { get; private set; }

        public MultiTypeConverter(string key, IDictionary<string, Type> mappings, Type defaultType = null)
        {
            this.Key = key;
            this.Mappings = mappings;
            this.DefaultType = defaultType;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return default(T);
            }

            var jsonObject = JObject.Load(reader);
            if (jsonObject.TryGetValue(Key, out var token) && 
                Mappings.TryGetValue((string)token, out var type))
            {
                var obj = Activator.CreateInstance(type);
                serializer.Populate(jsonObject.CreateReader(), obj);
                return obj;
            }
            else if (DefaultType != null)
            {
                var obj = Activator.CreateInstance(DefaultType);
                serializer.Populate(jsonObject.CreateReader(), obj);
                return obj;
            }

            return default(T);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new InvalidOperationException("Use default serialization.");
        }
    }
}
