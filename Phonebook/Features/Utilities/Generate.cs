namespace Phonebook.Features.Utilities;

public class Generate
{
    /// <summary>
    /// Generates 100 fake Norwegian contacts.
    /// </summary>
    /// <returns>A new list of fake contacts</returns>
    public static Contact[] GenerateFakeContacts()
    {
        Random random = new();
        
        Contact[] fakeContacts = new Contact[100];
        string[] firstNames = ["Ola", "Kari", "Petter", "Lars", "Mette", "Anne", "Per", "Hans", "Nina", "Erik"];
        string[] lastNames = ["Hansen", "Johansen", "Olsen", "Larsen", "Nilsen", "Berg", "Andreassen", "Haugen", "Moen", "Jensen"];
        string[] cities = ["Oslo", "Bergen", "Trondheim", "Stavanger", "Kristiansand", "Tromsø", "Drammen", "Sandnes", "Ålesund", "Bodø"];
        string[] streetNames = ["Karl Johans gate", "Dronningens gate", "Storgata", "Torggata", "Grensen", "Kirkeveien", "Bogstadveien", "Slemdalsveien", "Pilestredet", "Frognerveien"];

        for (int index = 0; index < fakeContacts.Length; index++)
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

            Contact contact = new(
                firstName,
                lastName,
                mobileNumber,
                birthday,
                address
            );
            
            fakeContacts[index] = contact;
        }
        
        // Serialize the fakeContacts array to a JSON string
        string jsonString = Serialize.Serializer(fakeContacts);
        
        // Writes a JSON file from the jsonString
        File.WriteAllText("../../../Logs/contacts.json", jsonString);
        
        return fakeContacts;
    }

    private static bool Contains(Contact[] contacts, Contact contact)
    {
        return contacts.Any(target => target.FirstName == contact.FirstName && target.LastName == contact.LastName);
    }
}