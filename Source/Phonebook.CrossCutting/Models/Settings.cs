namespace Phonebook.CrossCutting.Models
{
    public  interface ISettings
    {
        public MongoDbSettings MongoDbSettings { get;}
    }

    public class Settings : ISettings
    {
        public required MongoDbSettings MongoDbSettings { get; set; }
    }
}
