using static Phonebook.Features.Utilities.SearchCompare;
using Phonebook.Features.Utilities;

namespace Phonebook.Features;

public class Phonebook
{
    private static Contact[] _contacts = new Contact[100];
    
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
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
        ICollection<Contact> matchingContacts = [];

        foreach (Contact contact in _contacts)
        {
            if (Comparer(contact, criteria))
            {
                matchingContacts.Add(contact);
            }
        }

        return matchingContacts.ToArray();
    }
    
    
    public static void Sort(string category, string order)
    {
        Quicksort.QuickTextSort(_contacts, 0, _contacts.Length - 1, category, order);
    }
    
    public static void GenerateContacts()
    {
        _contacts = Generate.GenerateFakeContacts();
    }
}