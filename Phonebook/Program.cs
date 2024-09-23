﻿using Phonebook.Features.Contacts;

namespace Phonebook;

class Program
{
    static void Main(string[] args)
    {
        Contact[] contacts = ContactController.Generate();

        Console.WriteLine(ContactController.Display(contacts[5]));
    }
}