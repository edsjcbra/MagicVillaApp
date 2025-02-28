using MagicVIllaApp.Models.DTOs;

namespace MagicVIllaApp.Services.IServices;

public interface IVillaService
{
    Task<T> GetAllAsync<T>();
    Task<T> GetByIdAsync<T>(int id);
    Task<T> CreateAsync<T>(CreateVillaDto villaDto);
    Task<T> UpdateAsync<T>(UpdateVillaDto villaDto);
    Task<T> DeleteAsync<T>(int id);
}