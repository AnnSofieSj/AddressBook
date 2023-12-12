using AdressBook.Shared.Interfaces;
using AdressBook.Shared.Models;
using AdressBook.Shared.Services;
using ContactApp.Interfaces;

namespace ContactApp.Services;



public class MenuService : IMenuService
{
    private readonly IContactService _contactService = new ContactService();

    public void ShowMainMenu()
    {
        while (true)
        {
            MenuTitle("Huvudmeny");
            Console.WriteLine($"{"1.",-3} Lägg till ny kontakt");
            Console.WriteLine($"{"2.",-3} Visa information om kontakt");
            Console.WriteLine($"{"3.",-3} Visa alla kontakter i listan");
            Console.WriteLine($"{"4.",-3} Ta bort kontakt");
            Console.WriteLine($"{"5.",-3} Avsluta program");
            Console.WriteLine();
            Console.Write("Menyval: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowAddContact();
                    break;

                case "2":
                    ShowDetailedContact(); 
                    break;

                case "3":
                    ShowAllContacts();
                    break;

                case "4":
                    ShowRemoveContact();
                    break;
                case "5":
                    ShowExitApp();
                    break;

                default:
                    Console.WriteLine("Ogiltigt val. Tryck på valfri knapp för att välja igen.");
                    break;

            }

            Console.ReadKey();

        }
    }

    private void ShowAddContact()
    {
        IContact contact = new Contact();

        Console.WriteLine("Lägg till en ny kontakt, var god ange: ");
        Console.Write("Förnamn: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Efternamn: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("E-post: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Telefonnummer: ");
        contact.Phone = Console.ReadLine()!;

        Console.Write("Gatuadress: ");
        contact.Address = Console.ReadLine()!;

        Console.Write("Postnummer: ");
        contact.PostalCode = Console.ReadLine()!;

        Console.Write("Stad: ");
        contact.City = Console.ReadLine()!;

        _contactService.AddContactToList(contact);
    }

    private void ShowAllContacts()
    {
        var contacts = _contactService.GetContactsFromList();

        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName} {contact.Email}");
        }
    }

    private void ShowDetailedContact()
    {
        throw new NotImplementedException();
    }       

    private void ShowRemoveContact()
    {
        throw new NotImplementedException();
    }

    private void ShowExitApp()
    {
        throw new NotImplementedException();
    }

    private void MenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"*** {title} ***");
        Console.WriteLine();
    }
}
