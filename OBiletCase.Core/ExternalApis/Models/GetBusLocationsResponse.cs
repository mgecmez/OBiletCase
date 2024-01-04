using Newtonsoft.Json;

namespace OBiletCase.Core.ExternalApis.Models
{
    public class GetBusLocationsResponse
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "parent-id")]
        public int? ParentId { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "geo-location")]
        public GeoLocation GeoLocation { get; set; }

        [JsonProperty(PropertyName = "zoom")]
        public int Zoom { get; set; }

        [JsonProperty(PropertyName = "tz-code")]
        public string TzCode { get; set; }

        [JsonProperty(PropertyName = "weather-code")]
        public string WeatherCode { get; set; }

        [JsonProperty(PropertyName = "rank")]
        public int? Rank { get; set; }

        [JsonProperty(PropertyName = "reference-code")]
        public string ReferenceCode { get; set; }

        [JsonProperty(PropertyName = "city-id")]
        public int? CityId { get; set; }

        [JsonProperty(PropertyName = "reference-country")]
        public string ReferenceCountry { get; set; }

        [JsonProperty(PropertyName = "country-id")]
        public int? CountryId { get; set; }

        [JsonProperty(PropertyName = "keywords")]
        public string Keywords { get; set; }

        [JsonProperty(PropertyName = "city-name")]
        public string CityName { get; set; }

        [JsonProperty(PropertyName = "country-name")]
        public string CountryName { get; set; }
    }

    public class GeoLocation
    {
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "zoom")]
        public int Zoom { get; set; }
    }
}
