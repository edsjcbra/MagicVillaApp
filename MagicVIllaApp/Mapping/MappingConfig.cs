using AutoMapper;
using MagicVIllaApp.Models.DTOs;

namespace MagicVIllaApp.Mapping;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<VillaDto, CreateVillaDto>().ReverseMap();
        CreateMap<VillaDto, UpdateVillaDto>().ReverseMap();
        
        CreateMap<VillaNumberDto, CreateVillaNumberDto>().ReverseMap();
        CreateMap<VillaNumberDto, UpdateVillaNumberDto>().ReverseMap();
    }
}