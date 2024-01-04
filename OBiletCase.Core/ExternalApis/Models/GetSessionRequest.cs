using Newtonsoft.Json;

namespace OBiletCase.Core.ExternalApis.Models
{
    public class GetSessionRequest
    {
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }

        [JsonProperty(PropertyName = "connection")]
        public Connection Connection { get; set; }

        [JsonProperty(PropertyName = "browser")]
        public Browser Browser { get; set; }
    }

    public class Connection
    {
        [JsonProperty(PropertyName = "ip-address")]
        public string IpAddress { get; set; }

        [JsonProperty(PropertyName = "port")]
        public string Port { get; set; }
    }

    public class Browser
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
    }
}
