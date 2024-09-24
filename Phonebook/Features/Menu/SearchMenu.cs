namespace Phonebook.Features.Menu;

public class SearchMenu
{
    public static void SearchOption()
    {
        Console.Clear();
        
        Console.WriteLine("Write a term (First/Lastname or phone number) to search for: ");
        string searchTerm = Console.ReadLine();
        
        
        Contact[] searchResults = Phonebook.Search(searchTerm);
        WriteMenu(searchResults, searchResults.First());
        
        int index = 0;
        int displayIndex = 0;

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (index + 1 < searchResults.Length)
                {
                    index++;
                    WriteMenu(searchResults, searchResults[index]);
                }
            }
            
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (index - 1 >= 0)
                {
                    index--;
                    WriteMenu(searchResults, searchResults[index]);
                }
            }
            
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("\n" + Phonebook.Display(searchResults[index]));

                Console.WriteLine("\nPress escape to continue...");
                Console.ReadKey();
                
                Console.Clear();
                break;
            }
        }
    }
    
    private static void WriteMenu(Contact[] options, Contact selectedOption)
    {
        Console.Clear();

        foreach (Contact option in options)
        {
            if (option == selectedOption)
                Console.Write("> ");
            if (option != selectedOption)
                Console.Write($" ");

            Console.WriteLine(option.FirstName + " " + option.LastName + ", " + option.MobileNumber);
        }
    }
}