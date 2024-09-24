using System.Reflection;

namespace Phonebook.Features;

public class Contact(string firstName, string lastName, string mobileNumber, string birthday, string address)
{
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public string MobileNumber { get; } = mobileNumber;
    public string Birthday { get; } = birthday;
    public string Address { get; } = address;


    public string GetProperty(string propertyName)
    {
        //This is where we acquire the property value by its name
        return (string)GetType().GetProperty(propertyName)!.GetValue(this)!;
    }
}