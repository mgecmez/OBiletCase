﻿using Newtonsoft.Json;

namespace OBiletCase.Core.ExternalApis.Models
{
    public class GetBusJourneysResponse
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "parent-id")]
        public int ParentId { get; set; }

        [JsonProperty(PropertyName = "partner-name")]
        public string PartnerName { get; set; }

        [JsonProperty(PropertyName = "route-id")]
        public int RouteId { get; set; }

        [JsonProperty(PropertyName = "bus-type")]
        public string BusType { get; set; }

        [JsonProperty(PropertyName = "total-seats")]
        public int TotalSeats { get; set; }

        [JsonProperty(PropertyName = "available-seats")]
        public int AvailableSeats { get; set; }

        [JsonProperty(PropertyName = "journey")]
        public Journey Journey { get; set; }

        [JsonProperty(PropertyName = "features")]
        public List<Feature> Features { get; set; }

        [JsonProperty(PropertyName = "origin-location")]
        public string OriginLocation { get; set; }

        [JsonProperty(PropertyName = "destination-location")]
        public string DestinationLocation { get; set; }

        [JsonProperty(PropertyName = "is-active")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "origin-location-id")]
        public int OriginLocationId { get; set; }

        [JsonProperty(PropertyName = "destination-location-id")]
        public int DestinationLocationId { get; set; }

        [JsonProperty(PropertyName = "is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonProperty(PropertyName = "cancellation-offset")]
        public int? CancellationOffset { get; set; }

        [JsonProperty(PropertyName = "has-bus-shuttle")]
        public bool HasBusShuttle { get; set; }

        [JsonProperty(PropertyName = "disable-sales-without-gov-id")]
        public bool DisableSalesWithoutGovId { get; set; }

        [JsonProperty(PropertyName = "display-offset")]
        public TimeSpan DisplayOffset { get; set; }

        [JsonProperty(PropertyName = "partner-rating")]
        public decimal? PartnerRating { get; set; }
    }

    public class Feature
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("priority")]
        public byte? Priority { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonProperty("back-color")]
        public string BackColor { get; set; }

        [JsonProperty("fore-color")]
        public string ForeColor { get; set; }
    }

    public class Journey
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("stops")]
        public List<Stop> Stops { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("departure")]
        public DateTime Departure { get; set; }

        [JsonProperty("arrival")]
        public DateTime Arrival { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("duration")]
        public TimeSpan Duration { get; set; }

        [JsonProperty("original-price")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("internet-price")]
        public decimal InternetPrice { get; set; }

        [JsonProperty("booking")]
        public List<string> Booking { get; set; }

        [JsonProperty("bus-name")]
        public string BusName { get; set; }

        [JsonProperty("policy")]
        public Policy Policy { get; set; }

        [JsonProperty("features")]
        public List<string> Features { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("available")]
        public object Available { get; set; }
    }

    public class Policy
    {
        [JsonProperty("max-seats")]
        public int? MaxSeats { get; set; }

        [JsonProperty("max-single")]
        public int? MaxSingle { get; set; }

        [JsonProperty("max-single-males")]
        public int? MaxSingleMales { get; set; }

        [JsonProperty("max-single-females")]
        public int? MaxSingleFemales { get; set; }

        [JsonProperty("mixed-genders")]
        public bool MixedGenders { get; set; }

        [JsonProperty("gov-id")]
        public bool GovId { get; set; }

        [JsonProperty("lht")]
        public bool Lht { get; set; }
    }

    public class Stop
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("station")]
        public int? Station { get; set; }

        [JsonProperty("time")]
        public DateTime? Time { get; set; }

        [JsonProperty("is-origin")]
        public bool IsOrigin { get; set; }

        [JsonProperty("is-destination")]
        public bool IsDestination { get; set; }
    }
}
