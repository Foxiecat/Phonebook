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
        
        string[] options = ["Display All", "Search", "Sort", "Exit"];
        
        Menu mainMenu = new(prompt, options);
        int selectedIndex = mainMenu.Run();

        switch (selectedIndex)
        {
            case 0:
                Phonebook.DisplayAll();
                Console.WriteLine("\nPress Any Key To Exit To Main Menu...");
                Console.ReadKey(true);
                RunMainMenu();
                break;
            case 1:
                SearchMenu();
                break;
            case 2:
                SortMenu();
                break;
            case 3:
                Exit();
                break;
        }
    }

    
    private void SearchMenu()
    {
        Console.Clear();
        Console.WriteLine("Write a term (First/Lastname or phone number) to search for: ");

        string prompt = "Choose a contact for their full details: ";
        string searchContact = Console.ReadLine() ?? string.Empty;

        Contact[] contacts = Phonebook.Search(searchContact);
        string[] searchResults = new string[contacts.Length];

        for (int index = 0; index < contacts.Length; index++)
        {
            searchResults[index] = $"{contacts[index].FirstName} {contacts[index].LastName}, {contacts[index].MobileNumber}";
        }
        
        
        Menu menu = new (prompt, searchResults);
        int selectedContact = menu.Run();
        
        Contact contactDetails = contacts[selectedContact];

        Console.Clear();
        Console.WriteLine(Phonebook.Display(contactDetails));
        
        Console.WriteLine("\nPress Any Key To Exit To Main Menu...");
        Console.ReadKey(true);
        RunMainMenu();
    }

    
    private void SortMenu()
    {
        Console.Clear();
        
        // Categories to sort by:
        Console.WriteLine("What do you want to sort by (FirstName, LastName, MobileNumber, Birthday, Address?"); 
        string userCategoryInput = Console.ReadLine() ?? string.Empty;
        
        // Which order to sort by:
        Console.WriteLine("What order do you want to sort in (Ascending or Descending)?");
        string userOrderInput = Console.ReadLine() ?? string.Empty;
        
        Phonebook.Sort(userCategoryInput, userOrderInput);
        
        // Display sorted list and Exits
        Console.WriteLine("Phonebook as been sorted" +
                          "\nPress Any Key To Exit To Main Menu...");
        Console.ReadKey(true);
        RunMainMenu();
    }
    
    private void Exit()
    {
        Console.WriteLine("\nPress Any Key To Exit...");
        Console.ReadKey(true);
        
        Environment.Exit(0);
    }
}