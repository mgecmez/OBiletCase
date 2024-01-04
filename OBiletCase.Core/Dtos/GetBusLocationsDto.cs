namespace OBiletCase.Core.Dtos
{
    public class GetBusLocationsInDto
    {
        public string DeviceId { get; set; }
        public string SessionId { get; set; }
        public string Language { get; set; }
        public string Date { get; set; }
        public string Data { get; set; }
    }

    public class GetBusLocationsOutDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
    }
}
