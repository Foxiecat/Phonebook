using Phonebook.Features.Menu;
using static Phonebook.Features.Phonebook;

namespace Phonebook;

class Program
{
    static void Main(string[] args)
    { 
        GenerateContacts();
        
        MainMenu mainMenu = new();
        mainMenu.Start();
    }
}