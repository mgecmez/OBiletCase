namespace OBiletCase.Core.Dtos
{
    public class GetClientSessionInDto
    {
        public int Type { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
    }

    public class GetClientSessionOutDto
    {
        public string DeviceId { get; set; }
        public string SessionId { get; set; }
    }
}
