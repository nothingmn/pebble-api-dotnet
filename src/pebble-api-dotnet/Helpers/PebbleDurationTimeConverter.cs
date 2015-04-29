using System;
using Newtonsoft.Json;

namespace pebble_api_dotnet.Helpers
{
    public class PebbleDurationTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                TimeSpan ts = (TimeSpan)value;
                writer.WriteValue(ts.TotalMinutes);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            bool isNullable = objectType == typeof(Nullable);
            Type type = isNullable ? Nullable.GetUnderlyingType(objectType) : objectType;
            if (reader.TokenType == JsonToken.Null)
            {
                return (object)null;
            }

            int val = (int)existingValue;
            return TimeSpan.FromMinutes(val);
        }

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(int));
        }
    }
}