namespace UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using Core;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Converters;

    public static class FormattingConfig
    {
        private static readonly IEnumerable<JsonConverter> converters = GetCustomConverters();
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        };

        private static IEnumerable<JsonConverter> GetCustomConverters()
        {
            var targetType = typeof (EnumerationConverter<>);

            return from type in targetType.Assembly.GetTypes()
                   where type.IsSubclassOf(targetType)
                   let instance = (JsonConverter)Activator.CreateInstance(type)
                   select instance;
        }

        public static void Register(HttpConfiguration configuration)
        {
            configuration.Formatters.Clear();
            converters.ForEach(_settings.Converters.Add);
            configuration.Formatters.Add(new JsonMediaTypeFormatter { SerializerSettings = _settings });
        }
    }
}