using Microsoft.AspNetCore.Mvc;
using Phonebook.Domain.Entities;
using Phonebook.Infrastructure.Data;

namespace Phonebook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhonebookController : ControllerBase
    {
        private readonly IMongoDbContext _context;

        public PhonebookController(IMongoDbContext context)
        {
            _context = context;
        }

        [HttpGet("Teste")]
        public IActionResult Teste()
        {
            return Ok("Deu certo");
        }


        [HttpPost("insert-test")]
        public async Task<IActionResult> InsertTest()
        {
            var contato = new Contact
            {
                Name = "João Silva",
                Phone = "11999999999",
                Email = "joao@email.com",
                DateOfBirth = DateTime.Now,
                Addresses = new List<string> { "Rua A, 123", "Rua B, 456" }
            };

            await _context.Contacts.InsertOneAsync(contato);

            return Ok("Contato inserido com sucesso!");
        }

    }
}
