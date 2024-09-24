namespace Phonebook.Features.Menu;

public class Options(string menuOption, Action selectedOption)
{
    public string MenuOption { get; } = menuOption;
    public Action SelectedOption { get; } = selectedOption;
}