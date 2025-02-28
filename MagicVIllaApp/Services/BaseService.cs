using System.Text;
using System.Text.Json.Serialization;
using MagicVIllaApp.Models;
using MagicVIllaApp.Services.IServices;
using Newtonsoft.Json;

namespace MagicVIllaApp.Services;

public class BaseService : IBaseService
{
    public ApiResponse? ApiResponse { get; set; }
    public IHttpClientFactory httpClient { get; set; }
    
    public BaseService(IHttpClientFactory httpClient)
    {
        this.ApiResponse = new ApiResponse();
        this.httpClient = httpClient;
    }
    
    public async Task<T> SendAsync<T>(ApiRequest apiRequest)
    {
        try
        {
            var client = httpClient.CreateClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("Accept", "application/json");
            request.RequestUri = new Uri(apiRequest.Url);
            if (apiRequest.Data != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                    Encoding.UTF8, "application/json");
            }

            switch (apiRequest.ApiType)
            {
                case Utility.StaticFilesApiType.ApiType.GET:
                    request.Method = HttpMethod.Get;
                    break;
                case Utility.StaticFilesApiType.ApiType.POST:
                    request.Method = HttpMethod.Post;
                    break;
                case Utility.StaticFilesApiType.ApiType.PUT:
                    request.Method = HttpMethod.Put;
                    break;
                case Utility.StaticFilesApiType.ApiType.DELETE:
                    request.Method = HttpMethod.Delete;
                    break;
            }
            HttpResponseMessage response = null;
            response = await client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
        catch (Exception e)
        {
            var dto = new ApiResponse
            {
                ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                IsSucess = false,
            };
            var json = JsonConvert.SerializeObject(dto);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}