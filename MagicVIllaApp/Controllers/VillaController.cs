using AutoMapper;
using MagicVIllaApp.Models;
using MagicVIllaApp.Models.DTOs;
using MagicVIllaApp.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVIllaApp.Controllers;

public class VillaController : Controller
{
    private readonly IVillaService _villaService;
    private readonly IMapper _mapper;
    public VillaController(IVillaService villaService, IMapper mapper)
    {
        _villaService = villaService;
        _mapper = mapper;
    }
    public async Task<IActionResult> IndexVilla()
    {
        List<VillaDto> villaDtos = new();
        
        var response = await _villaService.GetAllAsync<ApiResponse>();
        if (response != null && response.IsSucess)
        {
            villaDtos = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.ApiContent));
        }
        return View(villaDtos);
    }
    
}