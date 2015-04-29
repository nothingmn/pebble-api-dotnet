using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace pebble_api_dotnet
{
    public enum Methods
    {
        PUT,
        POST,
        DELETE
    }

    public class TimelineRequest
    {
        public TimelineRequest()
        {
            Method = Methods.PUT;
            Headers = new Dictionary<string, string>();
        }

        public Methods Method { get; set; }

        public string EndPoint { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public Pin Pin { get; set; }

        public string Body
        {
            get
            {
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                };
                var body = Newtonsoft.Json.JsonConvert.SerializeObject(Pin, jsonSerializerSettings);
                return body;
            }
        }
    }
}