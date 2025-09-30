//using MediatR;
//using Phonebook.Domain.Entities;
//using Phonebook.Domain.Interfaces;
//using Phonebook.Domain.Results;
//using Phonebook.Application.Input.Handlers.Commands;

//public class UpdateContactCommandHandler(IContactRepository Repository) : IRequestHandler<UpdateContactCommand, ResultData<Contact>>
//{
//    public async Task<ResultData<Contact>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
//    {
//        ResultData<Contact> result;
//        ResultData<Contact> contactEntity = await Repository.GetContactByIdAsync(request.Id, cancellationToken);

//        if (!contactEntity.IsSuccess || contactEntity.Data == null)
//        {
//            result = ResultData<Contact>.Failure("Contato não encontrado");
//            return result;
//        }
//        else
//        {
//            var contact = contactEntity.Data;
//            contact.Name = request.Name;
//            contact.Phone = request.Phone;
//            contact.Email = request.Email;
//            contact.DateOfBirth = request.DateOfBirth;
//            contact.AddAddresses(request.Addresses);

//            result = await Repository.UpdadeContactAsync(contact);
//            return result;
//        }
//    }
//}
