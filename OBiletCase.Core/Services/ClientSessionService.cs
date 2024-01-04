using OBiletCase.Core.Dtos;
using OBiletCase.Core.ExternalApis;
using OBiletCase.Core.ExternalApis.Models;

namespace OBiletCase.Core.Services
{
    public class ClientSessionService
    {
        private readonly OBiletApiService _oBiletApiService;

        public ClientSessionService(OBiletApiService oBiletApiService) 
        {
            _oBiletApiService = oBiletApiService;
        }

        public ResponseDto<GetClientSessionOutDto> GetClientSession(GetClientSessionInDto inDto) 
        {
            var apiResponse = _oBiletApiService.GetSession(new GetSessionRequest
            {
                Type = inDto.Type,
                Browser = new Browser
                {
                    Name = inDto.BrowserName,
                    Version = inDto.BrowserVersion
                },
                Connection = new Connection
                {
                    IpAddress = inDto.IpAddress,
                    Port = inDto.Port,
                }
            });

            if (apiResponse == null)
            {
                return new ResponseDto<GetClientSessionOutDto>
                {
                    Errors = "Bilinmeyen bir hata olustu!"
                };
            }

            if (apiResponse.Status != "Success")
            {
                return new ResponseDto<GetClientSessionOutDto>
                {
                    Errors = apiResponse.UserMessage
                };
            }

            return new ResponseDto<GetClientSessionOutDto>
            {
                Data = new GetClientSessionOutDto
                {
                    DeviceId = apiResponse.Data.DeviceId,
                    SessionId = apiResponse.Data.SessionId,
                }
            };
        }
    }
}
