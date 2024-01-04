using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OBiletCase.Core.ExternalApis.Models;
using System.Net.Http.Headers;
using System.Text;

namespace OBiletCase.Core.ExternalApis
{
    public class OBiletApiService
    {
        private HttpClient _httpClient;
        private readonly OBiletApiConfig _obiletApiConfig;

        public OBiletApiService(IOptionsMonitor<OBiletApiConfig> obiletApiConfig, HttpClient httpClient)
        {
            _obiletApiConfig = obiletApiConfig.CurrentValue;

            httpClient.BaseAddress = new Uri(_obiletApiConfig.BaseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", _obiletApiConfig.Token);

            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(10);
        }

        public BaseResponse<GetSessionResponse> GetSession(GetSessionRequest request)
        {
            try
            {
                var requestData = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestData, Encoding.UTF8, "application/json");
                var url = _obiletApiConfig.ClientApi + "GetSession";

                using (var response = _httpClient.PostAsync(url, content).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = JsonConvert.DeserializeObject<BaseResponse<GetSessionResponse>>(response.Content.ReadAsStringAsync().Result);

                        return apiResponse;
                    }
                    else
                    {
                        var errMsg = $"oBiletApi GetSession StatusCode is: {response.StatusCode}";
                        return new BaseResponse<GetSessionResponse> { UserMessage = errMsg };
                    }
                }
            }
            catch (Exception ex)
            {
                var errMsg = "oBiletApi GetSession Error";
                return new BaseResponse<GetSessionResponse> { UserMessage = errMsg };
            }
        }

        public BaseResponse<List<GetBusLocationsResponse>> GetBusLocations(BaseRequest<string> request)
        {
            try
            {
                var requestData = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestData, Encoding.UTF8, "application/json");
                var url = _obiletApiConfig.LocationApi + "GetBusLocations";

                using (var response = _httpClient.PostAsync(url, content).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = JsonConvert.DeserializeObject<BaseResponse<List<GetBusLocationsResponse>>>(response.Content.ReadAsStringAsync().Result);

                        return apiResponse;
                    }
                    else
                    {
                        var errMsg = $"oBiletApi GetBusLocations StatusCode is: {response.StatusCode}";
                        return new BaseResponse<List<GetBusLocationsResponse>> { UserMessage = errMsg };
                    }
                }
            }
            catch (Exception ex)
            {
                var errMsg = "oBiletApi GetBusLocations Error";
                return new BaseResponse<List<GetBusLocationsResponse>> { UserMessage = errMsg };
            }
        }

        public BaseResponse<List<GetBusJourneysResponse>> GetBusJourneys(BaseRequest<GetBusJourneysRequest> request)
        {
            try
            {
                var requestData = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestData, Encoding.UTF8, "application/json");
                var url = _obiletApiConfig.JourneyApi + "GetBusJourneys";

                using (var response = _httpClient.PostAsync(url, content).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = JsonConvert.DeserializeObject<BaseResponse<List<GetBusJourneysResponse>>>(response.Content.ReadAsStringAsync().Result);

                        return apiResponse;
                    }
                    else
                    {
                        var errMsg = $"oBiletApi GetBusJourneys StatusCode is: {response.StatusCode}";
                        return new BaseResponse<List<GetBusJourneysResponse>> { UserMessage = errMsg };
                    }
                }
            }
            catch (Exception ex)
            {
                var errMsg = "oBiletApi GetBusJourneys Error";
                return new BaseResponse<List<GetBusJourneysResponse>> { UserMessage = errMsg };
            }
        }
    }
}
