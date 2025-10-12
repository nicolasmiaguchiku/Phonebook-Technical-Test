using FluentAssertions;
using FluentValidation;
using Mattioli.Configurations.Models;
using Moq;
using Phonebook.Application.Input.Handlers.Commands;
using Phonebook.Application.Validators;
using Phonebook.Domain.Dtos.Requests;
using Phonebook.Domain.Dtos.Response;
using Phonebook.Domain.Interfaces;
using Xunit.Abstractions;

namespace Phonebook.Tests.Commands
{
    public class AddContactCommandHandlerTest
    {
        private readonly Mock<IContactRepository> _mockContactContactRepository;
        private readonly IValidator<AddContactCommand> _validator;
        private readonly AddContactCommandHandler _handler;
        private readonly ITestOutputHelper _output;

        public AddContactCommandHandlerTest(ITestOutputHelper output)
        {
            _mockContactContactRepository = new Mock<IContactRepository>();
            _validator = new AddContactValidation();
            _handler = new AddContactCommandHandler(_mockContactContactRepository.Object, _validator);
            _output = output;
        }

        [Fact]
        public async Task WhenAddNewContactWhenTheRequestIsValidThenContactShouldBeInsertedAsync()
        {
            //Arrange
            var command = new AddContactCommand(new AddContactRequest
            {
                ContactId = Guid.NewGuid().ToString(),
                Name = "teste",
                Phone = "11999999999",
                Email = "teste@teste.com",
                DateOfBirth = new DateTime(2000, 7, 17),
                Addresses = ["Rua Teste, 123"]
            });

            _output.WriteLine($"Contato inserido: {command}");

            _mockContactContactRepository
                .Setup(r => r.AddContactAsync(It.IsAny<AddContactRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result<ContactResponse>.Success(new ContactResponse
                {
                    ContactId = command.AddContactRequest.ContactId,
                    Name = command.AddContactRequest.Name,
                    Email = command.AddContactRequest.Email,
                    Phone = command.AddContactRequest.Phone,
                    Addresses = command.AddContactRequest.Addresses,
                    DateOfBirth = command.AddContactRequest.DateOfBirth
                }));

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            result.IsSuccess
                .Should()
                .BeTrue();

            result
                .Should()
                .NotBeNull();

            result.Data
                .Should()
                .NotBeNull();

            _output.WriteLine($"Contato inserido: {result.Data.Name}");
        }
    }
}
