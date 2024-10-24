namespace Phonebook.Features.Utilities;

public class SearchCompare
{
    public static bool Comparer(Contact contact, string criteria)
    {
        return typeof(Contact).GetProperties()
            .Select(property => property.GetValue(contact)?.ToString())
            .Any(propertyValue =>
                !string.IsNullOrEmpty(propertyValue) && 
                propertyValue.Contains(criteria));
    }
}