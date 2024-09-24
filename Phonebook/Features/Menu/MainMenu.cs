using static Phonebook.Features.Phonebook;
namespace Phonebook.Features.Menu;

public class MainMenu
{
    private static Options[] _options;

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

        ConsoleKeyInfo keyInfo;
        {
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
    }
}