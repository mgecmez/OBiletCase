using Newtonsoft.Json;

namespace OBiletCase.Core.ExternalApis.Models
{
    public class BaseResponse<T>
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "user-message")]
        public string UserMessage { get; set; }

        [JsonProperty(PropertyName = "api-request-id")]
        public string ApiRequestId { get; set; }

        [JsonProperty(PropertyName = "controller")]
        public string Controller { get; set; }
    }
}
