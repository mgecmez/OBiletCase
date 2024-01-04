using Newtonsoft.Json;

namespace OBiletCase.Core.ExternalApis.Models
{
    public class GetBusJourneysRequest
    {
        [JsonProperty(PropertyName = "origin-id")]
        public int OriginId { get; set; }

        [JsonProperty(PropertyName = "destination-id")]
        public int DestinationId { get; set; }

        [JsonProperty(PropertyName = "departure-date")]
        public string DepartureDate { get; set; }
    }
}
