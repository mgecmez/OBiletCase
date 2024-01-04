using Newtonsoft.Json;

namespace OBiletCase.Core.ExternalApis.Models
{
    public class BaseRequest
    {
        [JsonProperty(PropertyName = "device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
    }

    public class BaseRequest<T> : BaseRequest where T : class
    {
        [JsonProperty(PropertyName = "data")]
        public T? Data { get; set; }
    }

    public class DeviceSession
    {
        [JsonProperty(PropertyName = "session-id")]
        public string SessionId { get; set; }

        [JsonProperty(PropertyName = "device-id")]
        public string DeviceId { get; set; }
    }
}
