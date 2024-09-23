using System.Runtime.InteropServices.JavaScript;
using static Phonebook.Features.Utilities;
using Bogus;

namespace Phonebook.Features.Contacts;

public class ContactController
{
    public static string Display(Contact contact)
    {
    }

    public Contact[] Search(string criteria)
    {
        throw new NotImplementedException();
    }

    public Contact[] Sort(string criterion)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Generates 100 fake Norwegian contacts.
    /// </summary>
    /// <returns>A new list of fake contacts</returns>
    public static Contact[] Generate()
    {
        // Sets the Faker locale to Norwegian
        Faker faker = new("nb_NO");
        
        Contact[] fakeContacts = new Contact[100];
        
        for (int index = 0; index < 100; index++)
        {
            Contact contact = new()
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                MobileNumber = faker.Random.Int(40000000, 99999999),
                Birthday = faker.Date.Between(DateTime.Now.AddYears(-80), DateTime.Now.AddYears(-18)).ToString("dd/MM/yyyy"),
                Address = faker.Address.StreetAddress() + ", " + faker.Address.City()
            };
            
            fakeContacts[index] = contact;
        }
        
        // Serialize the fakeContacts array to a JSON string
        string jsonString = Serialize(fakeContacts);
        
        // Writes a JSON file from the jsonString
        File.WriteAllText("../../../Logs/contacts.json", jsonString);
        
        return fakeContacts;
    }
}