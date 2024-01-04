namespace OBiletCase.Core.Dtos
{
    public class GetBusJourneyInDto
    {
        public string DeviceId { get; set; }
        public string SessionId { get; set; }
        public string Language { get; set; }
        public string Date { get; set; }
        public JourneyData Data { get; set; }
    }

    public class JourneyData
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public string DepartureDate { get; set; }
    }

    public class GetBusJourneyOutDto
    {
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public string DepartureDate { get; set; }
        public List<BusJourneyDto> BusJourneys { get; set; }
    }

    public class BusJourneyDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}
