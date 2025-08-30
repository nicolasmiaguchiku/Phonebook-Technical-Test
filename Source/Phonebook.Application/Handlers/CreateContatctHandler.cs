using Phonebook.Application.Commands;
using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using Phonebook.Shared.Results;


namespace Phonebook.Application.Handlers
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, ResultData<Contact>>
    {
        private readonly IContactRepository _repository;

        public CreateContactHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultData<Contact>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contato = new Contact
            {
                Name = request.Nome,
                Phone = request.Telefone,
                Email = request.Email,
                DateOfBirth = request.DataNascimento,
                Addresses = request.Enderecos
            };

            return await _repository.CreateContact(contato);
        }
    }
}
