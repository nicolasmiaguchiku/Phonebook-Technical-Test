namespace Phonebook.WebApi.Dtos
{
    public record UpdateContactDto(
    string Name,
    string Phone,
    string Email,
    DateTime DateOfBirth,
    IEnumerable<string> Addresses);
}
