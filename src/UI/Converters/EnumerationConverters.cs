using System;
using Core.Enumeration;
using Newtonsoft.Json;

namespace UI.Converters
{
    public class LinkConverter : EnumerationConverter<Link>
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Link.FromValue((string) reader.Value);
        }
    }

    public class CategoryConverter : EnumerationConverter<Category>
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Category.FromValue((string) reader.Value);
        }
    }

    public class LocationConverter : EnumerationConverter<Location>
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Location.FromValue((string) reader.Value);
        }
    }

    public abstract class EnumerationConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }

        public abstract override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer);

        public override bool CanConvert(Type objectType)
        {
            return typeof (T).IsAssignableFrom(objectType);
        }
    }
}