namespace Phonebook.Features;

public class Contact
{
    public string FirstName { get; }
    public string LastName { get; }
    public string MobileNumber { get; }
    public string Birthday { get; }
    public string Address { get; }

    public Contact(string firstName, string lastName, string mobileNumber, string birthday, string address)
    {
        FirstName = firstName;
        LastName = lastName;
        MobileNumber = mobileNumber;
        Birthday = birthday;
        Address = address;
    }
}