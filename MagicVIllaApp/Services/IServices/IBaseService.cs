using MagicVIllaApp.Models;

namespace MagicVIllaApp.Services.IServices;

public interface IBaseService
{
    ApiResponse? ApiResponse { get; set; }
    Task<T> SendAsync<T>(ApiRequest apiRequest);
}