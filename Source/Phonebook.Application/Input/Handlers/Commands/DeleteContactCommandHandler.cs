using MediatR;
using Phonebook.Domain.Interfaces;
using Mattioli.Configurations.Models;

namespace Phonebook.Application.Input.Handlers.Commands
{
    public class DeleteContactCommandHandler(IContactRepository Repository) : IRequestHandler<DeleteContactCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var result = await Repository.DeleteContactAsync(request.queryFilter, cancellationToken);
            return result;
        }
    }
}
