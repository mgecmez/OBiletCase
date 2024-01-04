using Newtonsoft.Json;

namespace OBiletCase.Core.ExternalApis.Models
{
    public class GetSessionResponse
    {
        [JsonProperty(PropertyName = "session-id")]
        public string SessionId { get; set; }

        [JsonProperty(PropertyName = "device-id")]
        public string DeviceId { get; set; }
    }
}
