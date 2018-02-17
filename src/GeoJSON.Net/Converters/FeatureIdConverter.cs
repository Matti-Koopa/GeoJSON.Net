using System;
using Newtonsoft.Json;

namespace GeoJSON.Net.Converters
{
    public class FeatureIdConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (long.TryParse(value.ToString(), out long longValue))
            {
                writer.WriteValue(longValue);
                return;
            }

            if (decimal.TryParse(value.ToString(), out decimal decimalValue))
            {
                writer.WriteValue(decimalValue);
                return;
            }

            writer.WriteValue(value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<string>(reader);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
