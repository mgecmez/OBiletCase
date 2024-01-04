using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using OBiletCase.Core.Dtos;
using OBiletCase.Core.Services;
using OBiletCase.Web.Models;
using System.ComponentModel.Design;
using System.Diagnostics;
using Wangkanai.Detection.Services;

namespace OBiletCase.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDetectionService _detectionService;
        private readonly IMemoryCache _memoryCache;
        private readonly ClientSessionService _clientSessionService;
        private readonly BusLocationService _busLocationService;
        private readonly BusJourneyService _busJourneyService;

        public HomeController(
            ILogger<HomeController> logger,
            IDetectionService detectionService,
            IMemoryCache memoryCache,
            ClientSessionService clientSessionService,
            BusLocationService busLocationService,
            BusJourneyService busJourneyService
        )
        {
            _logger = logger;
            _detectionService = detectionService;
            _memoryCache = memoryCache;
            _clientSessionService = clientSessionService;
            _busLocationService = busLocationService;
            _busJourneyService = busJourneyService;
        }

        public IActionResult Index()
        {
            var clientInfos = GetClientInfos();
            if (clientInfos == null)
            {
                var response = _clientSessionService.GetClientSession(new GetClientSessionInDto
                {
                    BrowserName = _detectionService.Browser.Name.ToString(),
                    BrowserVersion = _detectionService.Browser.Version.ToString(),
                    IpAddress = "165.114.41.21",
                    Port = "5117",
                    Type = 7
                });

                if (string.IsNullOrEmpty(response.Errors) && response.Data != null)
                {
                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Append("client_info", JsonConvert.SerializeObject(response.Data), cookie);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult GetBusLocations(string search)
        {
            var clientInfos = GetClientInfos();
            if (clientInfos == null) return Json(null);

            var locations = GetBusLocations(search, clientInfos);
            if (locations == null) return Json(null);

            return Json(locations);
        }

        [Route("/seferler/{locations}/{departure}")]
        public IActionResult Journey(string locations, string departure)
        {
            var originLocation = int.Parse(locations.Split('-')[0]);
            var destinationLocation = int.Parse(locations.Split("-")[1]);

            var clientInfos = GetClientInfos();
            if (clientInfos == null) return RedirectToAction(nameof(Index));

            var response = _busJourneyService.GetBusJourneys(new GetBusJourneyInDto
            {
                Data = new JourneyData
                {
                    OriginId = originLocation,
                    DestinationId = destinationLocation,
                    DepartureDate = departure
                },
                DeviceId = clientInfos.DeviceId,
                SessionId = clientInfos.SessionId,
                Language = "tr-TR",
                Date = DateTime.Now.ToString("s")
            });

            if (!string.IsNullOrEmpty(response.Errors)) return RedirectToAction(nameof(Index));

            var busLocations = GetBusLocations(string.Empty, clientInfos);
            if (busLocations != null)
            {
                response.Data.DepartureDate = departure;
                response.Data.OriginLocation = busLocations.FirstOrDefault(x => x.Id == originLocation)?.Name ?? string.Empty;
                response.Data.DestinationLocation = busLocations.FirstOrDefault(x => x.Id == destinationLocation)?.Name ?? string.Empty;
            }

            return View(response.Data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private GetClientSessionOutDto? GetClientInfos()
        {
            var clientInfos = HttpContext.Request.Cookies["client_info"];
            if (clientInfos == null) return null;

            var info = JsonConvert.DeserializeObject<GetClientSessionOutDto>(clientInfos);
            return info;
        }

        private List<GetBusLocationsOutDto>? GetBusLocations(string search, GetClientSessionOutDto clientInfos)
        {
            var cacheData = _memoryCache.Get<List<GetBusLocationsOutDto>>($"bus-locations{(!string.IsNullOrEmpty(search) ? $"-{search}" : string.Empty)}");
            if (cacheData != null) return cacheData;

            var response = _busLocationService.GetBusLocations(new GetBusLocationsInDto
            {
                Data = search,
                DeviceId = clientInfos.DeviceId,
                SessionId = clientInfos.SessionId,
                Language = "tr-TR",
                Date = DateTime.Now.ToString("s")
            });

            if (!string.IsNullOrEmpty(response.Errors)) return null;

            _memoryCache.Set($"bus-locations{(!string.IsNullOrEmpty(search) ? $"-{search}" : string.Empty)}", response.Data, DateTimeOffset.Now.AddHours(1));

            return response.Data;
        }
    }
}