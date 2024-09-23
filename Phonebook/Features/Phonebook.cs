using System.Diagnostics;
using System.Reflection;
using static Phonebook.Features.Utilities;

namespace Phonebook.Features;

public class Phonebook
{
    private static Contact[] _contacts = new Contact[100];
    
    public static string Display(Contact contact)
    {
        string contactCardString = $"Name         : {contact.FirstName} {contact.LastName}" +
                                   $"Mobile Phone : {contact.MobileNumber}" +
                                   $"Date of Birth: {contact.Birthday}" +
                                   $"Address      : {contact.Address}";
        
        return contactCardString;
    }

    public Contact[] Search(string criteria)
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
        foreach (Contact contact in _contacts)
        {
            Console.WriteLine($"Unsorted: {contact.FirstName} {contact.LastName}");
        }
        
        QuickTextSort(_contacts, 0, _contacts.Length - 1, category, order);

        foreach (Contact contact in _contacts)
        {
            Console.WriteLine($"Sorted: {contact.FirstName} {contact.LastName}");
        }
    }

    static void QuickTextSort(Contact[] _contacts, int low, int high, string propertyName, string order)
    {
        if (high <= low) return;

        int j = Partition(_contacts, low, high, propertyName, order);

        QuickTextSort(_contacts, low, j - 1, propertyName, order);
        QuickTextSort(_contacts, j + 1, high, propertyName, order);
    }

    private static int Partition(Contact[] contactArray, int low, int high, string propertyName, string order)
    {
        //string pivot = contactArray[low].GetType().GetField(propertyName).ToString();
        
        string? pivot = contactArray[low].GetProperty(propertyName);
        
        int i = low;
        int j = high + 1;

        while (true)
        {
            if (order == "Ascending")
            {
                while (String.Compare(contactArray[++i].GetProperty(propertyName), pivot) < 0)
                { }

                while (String.Compare(pivot, contactArray[--j].GetProperty(propertyName)) < 0)
                { }
            }

            if (order == "Descending")
            {
                while (String.Compare(contactArray[++i].GetProperty(propertyName), pivot) > 0)
                { }

                while (String.Compare(pivot, contactArray[--j].GetProperty(propertyName)) > 0)
                { }
            }
            

            if (i >= j) break;

            Swap(contactArray, i, j);
        }
        
        Swap(contactArray, low, j);
        return j;
    }

    static void Swap(Contact[] array, int first, int second)
    {
        (array[first], array[second]) = (array[second], array[first]);
    }
    
    /// <summary>
    /// Generates 100 fake Norwegian contacts.
    /// </summary>
    /// <returns>A new list of fake contacts</returns>
    public static void Generate()
    {
        Random random = new();
        Contact[] fakeContacts = new Contact[100];
        string[] firstNames = ["Ola", "Kari", "Petter", "Lars", "Mette", "Anne", "Per", "Hans", "Nina", "Erik"];
        string[] lastNames = ["Hansen", "Johansen", "Olsen", "Larsen", "Nilsen", "Berg", "Andreassen", "Haugen", "Moen", "Jensen"];
        string[] cities = ["Oslo", "Bergen", "Trondheim", "Stavanger", "Kristiansand", "Tromsø", "Drammen", "Sandnes", "Ålesund", "Bodø"];
        string[] streetNames = ["Karl Johans gate", "Dronningens gate", "Storgata", "Torggata", "Grensen", "Kirkeveien", "Bogstadveien", "Slemdalsveien", "Pilestredet", "Frognerveien"];
        
        
        for (int index = 0; index < 100; index++)
        {
            // Generates a random date of birth
            DateTime earliestDate = new(1960, 1, 1);
            int dateRange = (DateTime.Today - earliestDate).Days;
            DateTime randomDate = earliestDate.AddDays(random.Next(dateRange));
        
            // Generates a random address
            string street = streetNames[random.Next(streetNames.Length)];
            string city = cities[random.Next(streetNames.Length)];
            int houseNumber = random.Next(1, 20);
            
            // Generates random contact details
            string firstName = firstNames[random.Next(firstNames.Length)];
            string lastName = lastNames[random.Next(lastNames.Length)];
            string mobileNumber = "9" + random.Next(1000000, 9999999);
            string birthday = randomDate.ToString("dd/MM/yyyy");
            string address = $"{street} {houseNumber}, {city}";
            
            Contact contact = new Contact
            (
                firstName,
                lastName,
                mobileNumber,
                birthday,
                address
            );
            
            fakeContacts[index] = contact;
        }
        
        // Serialize the fakeContacts array to a JSON string
        string jsonString = Serialize(fakeContacts);
        
        // Writes a JSON file from the jsonString
        File.WriteAllText("../../../Logs/contacts.json", jsonString);
        
        _contacts = fakeContacts;
    }
}