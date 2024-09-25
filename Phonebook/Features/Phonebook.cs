using Phonebook.Features.Utilities;

namespace Phonebook.Features;

public class Phonebook
{
    private static Contact[] Contacts = new Contact[100];
    
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
        foreach (Contact contact in Contacts)                    
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName}, {contact.MobileNumber}" + "\n");
        }
    }

    public static Contact[] Search(string criteria)
    {
        Stack<Contact> matchingContacts = new();

        for (int index = 0; index < Contacts.Length; index++)
        {
            Contact contact = Contacts[index];
            
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
        quicksort.QuickTextSort(Contacts, 0, Contacts.Length - 1, category, order);
    }

    public static void GenerateContacts()
    {
        Contacts = Generate.GenerateFakeContacts();
    }
}