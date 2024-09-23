namespace Phonebook;

class Program
{
    static void Main(string[] args)
    {
        Features.Phonebook.Generate();

        Features.Phonebook.Sort("FirstName", "Ascending");
    }
}