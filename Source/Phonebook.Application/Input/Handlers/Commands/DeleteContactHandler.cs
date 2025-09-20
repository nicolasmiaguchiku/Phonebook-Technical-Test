using MediatR;
using Phonebook.Domain.Interfaces;
using Phonebook.Domain.Results;

namespace Phonebook.Application.Input.Handlers.Commands
{
    public class DeleteContactHandler(IContactRepository Repository) : IRequestHandler<DeleteContactCommand, ResultData<bool>>
    {
        public async Task<ResultData<bool>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
           var result = await Repository.DeleteContactAsync(request.Id);
           return result;
        }
    }
}
