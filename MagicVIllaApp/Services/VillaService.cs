using MagicVIllaApp.Models;
using MagicVIllaApp.Models.DTOs;
using MagicVIllaApp.Services.IServices;
using MagicVIllaApp.Utility;

namespace MagicVIllaApp.Services;
public class VillaService : BaseService, IVillaService
{
    private readonly IHttpClientFactory _clientFactory;
    private string villaUrl;
    
    public VillaService(IHttpClientFactory clientFactory, IConfiguration config) : base(clientFactory)
    {
        _clientFactory = clientFactory;
        villaUrl = config.GetValue <string>("ServiceUrls:VillaAPI");
    }

    public Task<T> GetAllAsync<T>()
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = StaticFilesApiType.ApiType.GET,
            Url = villaUrl+"/api/VillaAPI",
        });
    }

    public Task<T> GetByIdAsync<T>(int id)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = StaticFilesApiType.ApiType.GET,
            Url = villaUrl+"/api/VillaAPI/"+id,
        });
    }

    public Task<T> CreateAsync<T>(CreateVillaDto villaDto)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = StaticFilesApiType.ApiType.POST,
            Url = villaUrl+"/api/VillaAPI",
            Data = villaDto
        });
    }

    public Task<T> UpdateAsync<T>(UpdateVillaDto villaDto)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = StaticFilesApiType.ApiType.PUT,
            Url = villaUrl+"/api/VillaAPI/" + villaDto.Id,
            Data = villaDto
        });
    }

    public Task<T> DeleteAsync<T>(int id)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = StaticFilesApiType.ApiType.DELETE,
            Url = villaUrl+"/api/VillaAPI/"+id,
        });
    }
}