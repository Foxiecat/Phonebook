namespace Phonebook.Features.Menu;

public class Menu
{
    private string _prompt;
    private string[] _options;
    private int _selectedIndex;

    public Menu(string prompt, string[] options)
    {
        _prompt = prompt;
        _options = options;
        _selectedIndex = 0;
    }

    private void DisplayOptions()
    {
        Console.WriteLine(_prompt);
        for (int index = 0; index < _options.Length; index++)
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

    public int Run()
    {
        ConsoleKey keyPressed;
        do
        {
            Console.Clear();
            DisplayOptions();
            
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;
            
            // Updates _selectedIndex based on arrow keys
            if (keyPressed == ConsoleKey.UpArrow)
            {
                _selectedIndex--;
                
                if (_selectedIndex == -1)
                    _selectedIndex = _options.Length - 1;
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                _selectedIndex++;
                
                if (_selectedIndex == _options.Length)
                    _selectedIndex = 0;
            }
            
        } while (keyPressed != ConsoleKey.Enter);
        
        return _selectedIndex;
    }
}