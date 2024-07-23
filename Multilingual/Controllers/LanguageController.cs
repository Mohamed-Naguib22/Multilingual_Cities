using Microsoft.AspNetCore.Mvc;
using Multilingual.Common;
using Multilingual.Data;

namespace Multilingual.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class LanguageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Language language)
        {
            await _context.Languages.AddAsync(language);
            await _context.SaveChangesAsync();
            return Created();
        }
    }
}
