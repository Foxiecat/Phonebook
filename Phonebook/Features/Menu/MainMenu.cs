using static Phonebook.Features.Phonebook;
namespace Phonebook.Features.Menu;

public class MainMenu
{
    public void Start()
    {
        Console.Title = "Phonebook";
        RunMainMenu();
    }

    private void RunMainMenu()
    {
        string prompt = """
                        
                        
                         ▄▄▄▄▄▄▄▄▄▄▄  ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄        ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄    ▄ 
                        ▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░▌      ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌  ▐░▌
                        ▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌░▌     ▐░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌ ▐░▌ 
                        ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌▐░▌    ▐░▌▐░▌          ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌▐░▌  
                        ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌ ▐░▌   ▐░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌░▌   
                        ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌  ▐░▌  ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌ ▐░▌       ▐░▌▐░▌       ▐░▌▐░░▌    
                        ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌▐░▌   ▐░▌ ▐░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌░▌   
                        ▐░▌          ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌    ▐░▌▐░▌▐░▌          ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌▐░▌  
                        ▐░▌          ▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄█░▌▐░▌     ▐░▐░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░▌ ▐░▌ 
                        ▐░▌          ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░▌      ▐░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌  ▐░▌
                         ▀            ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀        ▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀   ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀    ▀ 


                        What would you like to do?
                        (Use the Up and Down arrow keys to cycle through the options and press enter to select an option)
                        """;
        
        string[] options = ["Search", "Sort", "Exit"];
        
        Menu mainMenu = new Menu(prompt, options);
        int selectedIndex = mainMenu.Run();

        switch (selectedIndex)
        {
            case 0:
                Search();
                break;
            case 1:
                Sort();
                break;
            case 2:
                Exit();
                break;
        }
    }

    private void Search()
    {
        Console.Clear();
        Console.WriteLine("Write a term (First/Lastname or phone number) to search for: ");

        string prompt = "Choose a contact for their full details: ";
        string searchContact = Console.ReadLine() ?? string.Empty;

        List<Contact> contacts = Phonebook.Search(searchContact).ToList();

        SearchMenu searchMenu = new(prompt, contacts);
        Contact selectedContact = searchMenu.RunSearch();

        Console.Clear();
        Console.WriteLine(Display(selectedContact));
        
        Console.WriteLine("\nPress Any Key To Exit To Main Menu...");
        Console.ReadKey(true);
        RunMainMenu();
    }

    private void Sort()
    {
        
    }
    
    private void Exit()
    {
        Console.WriteLine("\nPress Any Key To Exit...");
        Console.ReadKey(true);
        
        Environment.Exit(0);
    }
    
    /*private static Options[] _options;

    public static void RenderMenu()
    { 
        int index = 0;

        _options =
        [
            new Options("Display All", DisplayAll),
            new Options("Search", SearchMenu.SearchOption),
            new Options("Sort", () => Sort("FirstName", "Ascending")),
            new Options("Exit", () => Environment.Exit(0))
        ];

        WriteMenu(_options, _options[index = 0]);

        {
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                    {
                        if (index + 1 < _options.Length)
                        {
                            index++;
                            WriteMenu(_options, _options[index]);
                        }

                        break;
                    }
                    case ConsoleKey.UpArrow:
                    {
                        if (index - 1 >= 0)
                        {
                            index--;
                            WriteMenu(_options, _options[index]);
                        }
                        break;
                    }
                    case ConsoleKey.Enter:
                    {
                        _options[index].SelectedOption.Invoke();

                        index = 0;
                        break;
                    }
                }
            } while (keyInfo.Key != ConsoleKey.X);

            Console.ReadKey();
        }
    }


    private static void WriteMenu(Options[] options, Options selectedOption)
    {
        Console.Clear();

        foreach (Options option in options)
        {
            if (option == selectedOption)
                Console.Write("> ");
            if (option != selectedOption)
                Console.Write($" ");

            Console.WriteLine(option.MenuOption);
        }
    }*/
}