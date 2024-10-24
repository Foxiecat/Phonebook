# Phonebook
## Developer Details
* Name: Danica Ellefsen Kvilhaug
* GitHub: https://github.com/Foxiecat

## Description
This application is a simple C# console based program made to manage a collection of contacts, i.e. A phonebook.

### Features:
1. A way to display the entire phonebook
2. Search: Search contacts based on First/lastName, MobileNumber, Birthday or Address
3. Display Searched: Choose one contact in the search results to get their full details
4. Sort: Sort the phonebook based on either FirstName, LastName or MobileNumber in either Ascending or Descending order

### How to use
1. Run ~\Phonebook\Phonebook\bin\Debug\net8.0\Phonebook.exe
2. Move up and down the menu with the Up/Down arrows
3. Press enter to choose a menu option

## Search solution:
The search function uses a simple linear search (Wanted to use binary search but just couldn't get it to work), and compares each contact's properties against the search criteria, if they match add it to the list of matching contacts. When the linear search has completed, return the ICollection<Contact> containing the search results.

## Sort solution:
The sort function uses a quicksort to quickly sort the list based on FirstName, LastName or MobileNumber in either Ascending or Descending order. Inside the partition function of the quicksort is a switch statement that decides if it's Ascending or Descending order, it then compares the current Contact against the pivot Contact.


## License
This project is licensed under the MIT License:


Copyright 2024 Danica Ellefsen Kvilhaug

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


