using Mattioli.Configurations.Models;
using Phonebook.Domain.Entities;

namespace Phonebook.Domain.Errors
{
    public class ContactErrors
    {
        public static readonly Error ContactNotExist = new("Nenhum Contato encontrado", "Nenhum contato foi encontrado tente novamente mais tarde");
        public static readonly Error IdInformedInvalid = new("Id invalido", "Formato do id informado está invalido");
    }
}
