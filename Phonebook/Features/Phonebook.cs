using Phonebook.Features.Utilities;

namespace Phonebook.Features;

public class Phonebook
{
    private static Contact[] _contacts = new Contact[100];
    
    public static string Display(Contact contact)
    {
        string contactCardString = $"""
                                     Name         : {contact.FirstName} {contact.LastName}
                                     Mobile Phone : {contact.MobileNumber}
                                     Date of Birth: {contact.Birthday}
                                     Address      : {contact.Address}
                                    """; 
        
        return contactCardString;
    }

    public static void DisplayAll()
    {
        foreach (Contact contact in _contacts)                    
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName}, {contact.MobileNumber}" + "\n");
        }
    }

    public static Contact[] Search(string criteria)
    {
        Stack<Contact> matchingContacts = new();

        for (int index = 0; index < _contacts.Length; index++)
        {
            Contact contact = _contacts[index];
            
            if (contact.FirstName.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                contact.LastName.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                contact.MobileNumber.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                contact.Birthday.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                contact.Address.Contains(criteria, StringComparison.OrdinalIgnoreCase))
            {
                matchingContacts.Push(contact);
            }
        }

        return matchingContacts.ToArray();
    }

    public static void Sort(string category, string order)
    {
        quicksort.QuickTextSort(_contacts, 0, _contacts.Length - 1, category, order);
    }

    public static void GenerateContacts()
    {
        _contacts = Generate.GenerateFakeContacts();
    }
}