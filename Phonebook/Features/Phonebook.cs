using System.Diagnostics;
using System.Reflection;
using static Phonebook.Features.Utilities;

namespace Phonebook.Features;

public class Phonebook
{
    private static Contact[] contacts { get; set; } = new Contact[100];
    
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

    public Contact[] Search(string criteria)
    {
        Stack<Contact> matchingContacts = new();

        for (int index = 0; index < contacts.Length; index++)
        {
            Contact contact = contacts[index];
            
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

    public Contact[] Sort(string category, string orderBy)
    {
        
    }

    static void QuickSort<T>(Contact[] contacts, int left, int right, string propertyName)
    {
        int leftIndex = left, rightIndex = right;
        Contact pivot = contacts[(left + right) / 2];
        Type fieldType = propertyName.GetType();

        while (leftIndex <= rightIndex)
        {
            while (contacts[leftIndex].GetType().GetField("propertyName").Equals(pivot))
            {
                
            }
        }
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
        
        contacts = fakeContacts;
    }
}