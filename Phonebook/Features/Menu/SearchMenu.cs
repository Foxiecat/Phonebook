namespace Phonebook.Features.Menu;

public class SearchMenu
{
    private string _prompt;
    private List<string> _options;
    private List<Contact> _contacts;
    private int _selectedIndex;

    public SearchMenu(string prompt, List<Contact> contacts)
    {
        _prompt = prompt;
        _contacts = contacts;
        _selectedIndex = 0;
    }

    private void DisplayOptions()
    {
        Console.WriteLine(_prompt);
        for (int index = 0; index < _options.Count; index++)
        {
            string currentOption = _options[index];
            string prefix;

            if (index == _selectedIndex)
            {
                prefix = "*";
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                prefix = " ";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            
            Console.WriteLine($"{prefix} << {currentOption} >>");
        }
        
        Console.ResetColor();
    }
    
    public Contact RunSearch()
    {
        ConsoleKey keyPressed;
        do
        {
            Console.Clear();
            
            foreach (Contact contact in _contacts)
            {
                _options.Add($"{contact.FirstName} {contact.LastName}, {contact.MobileNumber}");
            }
            
            DisplayOptions();
            
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;
            
            // Updates _selectedIndex based on arrow keys
            if (keyPressed == ConsoleKey.UpArrow)
            {
                _selectedIndex--;
                
                if (_selectedIndex == -1)
                    _selectedIndex = _options.Count - 1;
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                _selectedIndex++;
                
                if (_selectedIndex == _options.Count)
                    _selectedIndex = 0;
            }
            
        } while (keyPressed != ConsoleKey.Enter);
        
        return _contacts[_selectedIndex];
    }
}