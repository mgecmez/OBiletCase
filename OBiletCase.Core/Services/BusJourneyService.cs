using OBiletCase.Core.Dtos;
using OBiletCase.Core.ExternalApis;
using OBiletCase.Core.ExternalApis.Models;

namespace OBiletCase.Core.Services
{
    public class BusJourneyService
    {
        private readonly OBiletApiService _oBiletApiService;

        public BusJourneyService(OBiletApiService oBiletApiService)
        {
            _oBiletApiService = oBiletApiService;
        }

        public ResponseDto<GetBusJourneyOutDto> GetBusJourneys(GetBusJourneyInDto inDto)
        {
            var apiResponse = _oBiletApiService.GetBusJourneys(new BaseRequest<GetBusJourneysRequest>
            {
                Data = new GetBusJourneysRequest
                {
                    OriginId = inDto.Data.OriginId,
                    DestinationId = inDto.Data.DestinationId,
                    DepartureDate = inDto.Data.DepartureDate
                },
                DeviceSession = new DeviceSession()
                {
                    DeviceId = inDto.DeviceId,
                    SessionId = inDto.SessionId
                },
                Language = inDto.Language,
                Date = inDto.Date
            });

            if (apiResponse == null)
            {
                return new ResponseDto<GetBusJourneyOutDto>
                {
                    Errors = "Bilinmeyen bir hata olustu!"
                };
            }

            if (apiResponse.Status != "Success")
            {
                return new ResponseDto<GetBusJourneyOutDto>
                {
                    Errors = apiResponse.UserMessage
                };
            }

            var response = new ResponseDto<GetBusJourneyOutDto>();
            response.Data = new GetBusJourneyOutDto();
            response.Data.BusJourneys = apiResponse.Data.Select(x => new BusJourneyDto
            {
                Origin = x.Journey.Origin,
                Destination = x.Journey.Destination,
                DepartureDate = x.Journey.Departure,
                ArrivalDate = x.Journey.Arrival,
                Currency = x.Journey.Currency,
                Price = x.Journey.InternetPrice
            }).ToList();

            return response;
        }
    }
}
