using static Phonebook.Features.Utilities;
using Bogus;

namespace Phonebook.Features.Contacts;

public class Contact()
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int MobileNumber { get; set; }
    public string Birthday { get; set; }
    public string Address { get; set; }
}