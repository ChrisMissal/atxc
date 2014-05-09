namespace UI
{
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public static class FormattingConfig
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
        };

        public static void Register(HttpConfiguration configuration)
        {
            configuration.Formatters.Clear();
            configuration.Formatters.Add(new JsonMediaTypeFormatter { SerializerSettings = _settings });
        }
    }
}