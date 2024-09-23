using static Phonebook.Features.Utilities;
using Bogus;

namespace Phonebook.Features.Contacts;

public class Contact()
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int MobileNumber { get; init; }
    public string Birthday { get; init; }
    public string Address { get; init; }
}