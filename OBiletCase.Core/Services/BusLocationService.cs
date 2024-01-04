using OBiletCase.Core.Dtos;
using OBiletCase.Core.ExternalApis;
using OBiletCase.Core.ExternalApis.Models;

namespace OBiletCase.Core.Services
{
    public class BusLocationService
    {
        private readonly OBiletApiService _oBiletApiService;

        public BusLocationService(OBiletApiService oBiletApiService)
        {
            _oBiletApiService = oBiletApiService;
        }

        public ResponseDto<List<GetBusLocationsOutDto>> GetBusLocations(GetBusLocationsInDto inDto)
        {
            var apiResponse = _oBiletApiService.GetBusLocations(new BaseRequest<string>
            {
                Data = inDto.Data,
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
                return new ResponseDto<List<GetBusLocationsOutDto>>
                {
                    Errors = "Bilinmeyen bir hata olustu!"
                };
            }

            if (apiResponse.Status != "Success")
            {
                return new ResponseDto<List<GetBusLocationsOutDto>>
                {
                    Errors = apiResponse.UserMessage
                };
            }

            return new ResponseDto<List<GetBusLocationsOutDto>> 
            { 
                Data = apiResponse.Data.Select(x => new GetBusLocationsOutDto { Id = x.Id, Name = x.Name, CityId = x.CityId, CityName = x.CityName}).ToList()
            };
        }
    }
}
