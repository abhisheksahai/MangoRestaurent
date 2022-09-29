using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {
        private IHttpClientFactory _httpClient;
        public BaseService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("MangoAPI");
                client.DefaultRequestHeaders.Clear();

                HttpRequestMessage request = new HttpRequestMessage();
                request.Headers.Add("Accept", "application/json");
                request.RequestUri = new Uri(apiRequest.Url);
                if (apiRequest.Data != null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        request.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        request.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        request.Method = HttpMethod.Delete;
                        break;
                    default:
                        request.Method = HttpMethod.Get;
                        break;
                }
                HttpResponseMessage response = await client.SendAsync(request);
                var apiContent = await response.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessage = new List<string> { ex.Message },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}