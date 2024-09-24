using Phonebook.Features.Menu;
using static Phonebook.Features.Phonebook;

namespace Phonebook;

class Program
{
    static void Main(string[] args)
    { 
        Console.WriteLine("Generating Fake Contacts...");
        GenerateContacts();
        Console.WriteLine("Fake Contacts Generated\n");
        
        MainMenu mainMenu = new();
        mainMenu.Start();
    }
}