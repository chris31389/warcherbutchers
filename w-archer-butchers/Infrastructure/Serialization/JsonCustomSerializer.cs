using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WArcherButchers.Infrastructure.Serialization
{
    public static class JsonCustomSerializer
    {
        public static void Setup(JsonSerializerSettings jsonSerializerSettings)
        {
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }

        public static JsonSerializerSettings Create()
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            Setup(jsonSerializerSettings);
            return jsonSerializerSettings;
        }
    }
}