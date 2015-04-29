using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace pebble_api_dotnet
{
    public class Timeline
    {
        private readonly string _apiKey;
        private readonly string _apiRoot;
        public readonly string TimelineAPIRoot = "https://timeline-api.getpebble.com";
        private string Token = null;

        public Timeline(string apiKey,string apiRoot = null)
        {
            _apiKey = apiKey;
            _apiRoot = TimelineAPIRoot;
            if (!string.IsNullOrEmpty(apiRoot)) _apiRoot = apiRoot;
        }

        public async Task<TimelineResult> SendUserPin(string userToken, Pin pin)
        {
            if (string.IsNullOrEmpty(userToken)) throw new ArgumentNullException("userToken");
            if (pin == null) throw new ArgumentNullException("pin");

            var request = new TimelineRequest()
            {
                Pin = pin,
                EndPoint = "/v1/user/pins/" + pin.Id,
                Headers = new Dictionary<string, string>()
                {
                    {"X-User-Token", userToken}
                },
                Method = Methods.PUT
            };
            return await Send(request);
        }

        public async Task<TimelineResult> DeleteUserPin(string userToken, Pin pin)
        {
            if (string.IsNullOrEmpty(userToken)) throw new ArgumentNullException("userToken");
            if (pin == null) throw new ArgumentNullException("pin");

            var request = new TimelineRequest()
            {
                Pin = pin,
                EndPoint = "/v1/user/pins/" + pin.Id,
                Headers = new Dictionary<string, string>()
                {
                    {"X-User-Token", userToken}
                },
                Method = Methods.DELETE
            };
            return await Send(request);
        }

        public async Task<TimelineResult> sendSharedPin(IEnumerable<string> topics, Pin pin)
        {
            if (string.IsNullOrEmpty(_apiKey)) throw new ArgumentNullException("ApiKey");
            if (topics == null) throw new ArgumentNullException("topics");
            if (pin == null) throw new ArgumentNullException("pin");

            var request = new TimelineRequest()
            {
                Pin = pin,
                EndPoint = "/v1/shared/pins/" + pin.Id,
                Headers = new Dictionary<string, string>()
                {
                    {"X-API-Key", _apiKey},
                    {"X-PIN-Topics", string.Join(",", topics)},
                },
                Method = Methods.PUT
            };
            return await Send(request);
        }

        public async Task<TimelineResult> Subscribe(string userToken, string topic)
        {
            if (string.IsNullOrEmpty(userToken)) throw new ArgumentNullException("userToken");
            if (string.IsNullOrEmpty(topic)) throw new ArgumentNullException("topic");

            var request = new TimelineRequest()
            {
                EndPoint = "/v1/user/subscriptions/" + topic,
                Headers = new Dictionary<string, string>()
                {
                    {"X-User-Token", userToken}
                },
                Method = Methods.POST
            };
            return await Send(request);
        }

        public async Task<TimelineResult> Unsubscribe(string userToken, string topic)
        {
            if (string.IsNullOrEmpty(userToken)) throw new ArgumentNullException("userToken");
            if (string.IsNullOrEmpty(topic)) throw new ArgumentNullException("topic");

            var request = new TimelineRequest()
            {
                EndPoint = "/v1/user/subscriptions/" + topic,
                Headers = new Dictionary<string, string>()
                {
                    {"X-User-Token", userToken}
                },
                Method = Methods.DELETE
            };
            return await Send(request);
        }

        private async Task<TimelineResult> Send(TimelineRequest request)
        {
            var client = new HttpClient();

            var url = string.Format("{0}{1}", _apiRoot, request.EndPoint);

            HttpResponseMessage response = null;
            switch (request.Method)
            {
                case Methods.DELETE:
                    response = await client.DeleteAsync(url);
                    break;

                case Methods.POST:
                    var postBody = new StringContent(request.Body);
                    if (request.Headers != null && request.Headers.Count > 0)
                    {
                        foreach (var h in request.Headers)
                        {
                            postBody.Headers.Add(h.Key, h.Value);
                        }
                    }
                    postBody.Headers.ContentType.MediaType = "application/json";
                    response = await client.PostAsync(url, postBody);
                    break;

                case Methods.PUT:
                    var putBody = new StringContent(request.Body);
                    if (request.Headers != null && request.Headers.Count > 0)
                    {
                        foreach (var h in request.Headers)
                        {
                            putBody.Headers.Add(h.Key, h.Value);
                        }
                    }
                    putBody.Headers.ContentType.MediaType = "application/json";
                    response = await client.PutAsync(url, putBody);
                    break;
            }
            int code = (int)response.StatusCode;

            string errorMessage = null;
            if (ErrorCodes.ContainsKey(code)) errorMessage = ErrorCodes[code];
            var result = new TimelineResult(code, errorMessage);


#if DEBUG
            Debug.WriteLine(request.Body);
            Debug.WriteLine(code);
            Debug.WriteLine(result.ErrorDescription);

#endif

            return result;
        }

        private Dictionary<int, string> ErrorCodes = new Dictionary<int, string>()
        {
            {400, "The pin object submitted was invalid."},
            {403, "The API key submitted was invalid."},
            {410, "The user token submitted was invalid or does not exist."},
            {429, "Server is sending updates too quickly."},
            {503, "Could not save pin due to a temporary server error."},
        };
    }
}