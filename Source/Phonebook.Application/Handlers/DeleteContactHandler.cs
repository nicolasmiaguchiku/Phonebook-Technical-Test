using MediatR;
using Phonebook.Application.Commands;
using Phonebook.Domain.Interfaces;
using Phonebook.Shared.Results;

namespace Phonebook.Application.Handlers
{
    public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, ResultData<bool>>
    {
        private readonly IContactRepository _repositoryContact;

        public DeleteContactHandler(IContactRepository repository)
        {
            _repositoryContact = repository;
        }

        public async Task<ResultData<bool>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            return await _repositoryContact.DeleteContactAsync(request.Id);
        }
    }
}
