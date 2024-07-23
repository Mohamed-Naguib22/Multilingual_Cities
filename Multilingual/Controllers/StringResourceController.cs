using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multilingual.Common;
using Multilingual.Data;
using Multilingual.Entities;

namespace Multilingual.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class StringResourceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StringResourceController(ApplicationDbContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StringResource stringResource)
        {
            await _context.StringResources.AddAsync(stringResource);
            await _context.SaveChangesAsync();
            return Created();
        }
    }
}
