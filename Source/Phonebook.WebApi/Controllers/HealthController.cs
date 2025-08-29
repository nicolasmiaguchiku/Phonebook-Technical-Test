using Microsoft.AspNetCore.Mvc;
using Phonebook.Infrastructure.Data;

namespace Phonebook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IMongoDbContext _context;

        public HealthController(IMongoDbContext context)
        {
            _context = context;
        }
        [HttpGet("test-connection-alt")]
        public async Task<IActionResult> TestConnectionAlt()
        {
            try
            {
                var client = await _context.PingAsync();
                return Ok("✅ Conexão com MongoDB funcionando!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Erro ao conectar: {ex.Message}");
            }
        }

    }
}


