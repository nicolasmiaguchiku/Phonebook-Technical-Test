using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Application.Handlers.Commands;
using Phonebook.Application.Handlers.Queries;

namespace Phonebook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhonebookQuerieController(IMediator mediator) : ControllerBase
    {

        [HttpGet("GetAllContact-Phonebook")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllContactsQuery(), cancellationToken);
            return Ok(result);
        }


        [HttpGet("GetContactById/{id}")]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetContactByIdQuery(id), cancellationToken);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        
    }
}
