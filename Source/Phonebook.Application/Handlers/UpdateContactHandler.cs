//using MediatR;
//using Phonebook.Application.Commands;
//using Phonebook.Domain.Entities;
//using Phonebook.Domain.Interfaces;
//using Phonebook.Shared.Results;

//public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ResultData<Contact>>
//{
//    private readonly IContactRepository _repository;

//    public UpdateContactCommandHandler(IContactRepository repository)
//    {
//        _repository = repository;
//    }

//    public async Task<ResultData<Contact>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
//    {
//        var contact = await _repository.GetContactByIdAsync(request.Id);
//        if (contact == null)
//            return ResultData<Contact>.Failure("Contato não encontrado.");

//        if (!string.IsNullOrWhiteSpace(request.newName))
//            contact.Name = request.newName;
//        if (!string.IsNullOrWhiteSpace(request.newPhone))
//            contact.Phone = request.newPhone;
//        if (!string.IsNullOrWhiteSpace(request.newEmail))
//            contact.Email = request.newEmail;

//        contact.DateOfBirth = request.DateOfBirth;

//        if (!string.IsNullOrWhiteSpace(request.newAddresse))
//            contact.AddAddress(request.newAddresse);

//        await _repository.UpdadeContactAsync(contact);

//        return ResultData<Contact>.Success(contact, "Contato atualizado com sucesso.");
//    }
//}
