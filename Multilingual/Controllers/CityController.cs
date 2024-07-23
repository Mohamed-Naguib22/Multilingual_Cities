using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multilingual.Data;
using Multilingual.Dtos;
using Multilingual.Entities;
using Multilingual.Services;

namespace Multilingual.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class CityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;
        public CityController(ApplicationDbContext context, ILocalizationService localizationService, IMapper mapper) 
        {
            _context = context;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cityDtos = _mapper.Map<IEnumerable<GetCityDto>>(await _context.Cities.ToListAsync());
            await _localizationService.TranslateToArabicIfArabicLanguageSelected(cityDtos);
            return Ok(cityDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            return Created();
        }
    }
}
