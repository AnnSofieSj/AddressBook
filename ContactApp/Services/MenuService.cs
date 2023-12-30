using AdressBook.Shared.Interfaces;
using AdressBook.Shared.Models;
using ContactApp.Interfaces;

namespace ContactApp.Services;



public class MenuService(IContactService contactService) : IMenuService
{
    private readonly IContactService _contactService = contactService;

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

        Console.Clear();
        Console.WriteLine(" *** Skapa ny kontakt ***");
        Console.WriteLine();
        Console.WriteLine("Var god ange: ");
        Console.Write("Förnamn: ");
        contact.FirstName = Console.ReadLine()!;
        contact.FirstName = char.ToUpper(contact.FirstName[0]) + contact.FirstName.Substring(1);

        Console.Write("Efternamn: ");
        contact.LastName = Console.ReadLine()!;
        contact.LastName = char.ToUpper(contact.LastName[0]) + contact.LastName.Substring(1);

        Console.Write("E-postadress: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Telefonnummer: ");
        contact.Phone = Console.ReadLine()!;

        Console.Write("Gatuadress: ");
        contact.Address = Console.ReadLine()!;
        contact.Address = char.ToUpper(contact.Address[0]) + contact.Address.Substring(1);

        Console.Write("Postnummer: ");
        contact.PostalCode = Console.ReadLine()!;

        Console.Write("Stad: ");
        contact.City = Console.ReadLine()!;
        contact.City = char.ToUpper(contact.City[0]) + contact.City.Substring(1);

        _contactService.AddContactToList(contact);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Kontakt skapad. Tryck Enter för att komma tillbaks till huvudmenyn.");
    }

    private void ShowAllContacts()
    {
        var contacts = _contactService.GetContactsFromList();

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine(" *** Alla kontakter *** ");
        foreach (var contact in contacts)
        {
            Console.WriteLine();
            Console.WriteLine($" * {contact.FirstName} {contact.LastName} {contact.Email}");
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Tryck Enter för att komma tillbaks till huvudmenyn.");
    }

    private void ShowDetailedContact()
    {
        Console.Clear();
        Console.WriteLine(" *** Ange e-postadressen för den kontakt som du vill visa *** ");
        Console.Write("E-postadress: ");
        var contact = _contactService.GetContactFromList(Console.ReadLine()!);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine(" *** Information om kontakt *** ");
        Console.WriteLine();        
        Console.WriteLine($"{contact.FirstName} {contact.LastName}");       
        Console.WriteLine($"{contact.Address}");
        Console.WriteLine($"{contact.PostalCode} {contact.City}");
        Console.WriteLine();
        Console.WriteLine($"E-Postadress: {contact.Email}");
        Console.WriteLine($"Telefonnummer: {contact.Phone}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Tryck Enter för att komma tillbaks till huvudmenyn.");
    }       

    private void ShowRemoveContact()
    {
        Console.Clear();
        Console.WriteLine("*** Ange e-postadressen för den kontakt som du vill ta bort ***");
        Console.WriteLine();
        Console.Write("E-postadress: ");
        var remove = Console.ReadLine();

        Console.WriteLine("Är du säker på att du vill ta bort kontakten? (y/n): ");
        var option = Console.ReadLine() ?? "";

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            var contact = _contactService.RemoveContactFromList(remove!);
        }
        else
        {
            ShowMainMenu();
        }

        
        Console.Clear();
        Console.WriteLine("Kontakt borttagen. Tryck Enter för att komma tillbaks till huvudmenyn.");
        
    }

    private void ShowExitApp()
    {
        Console.Clear();
        Console.Write("Är du säker på att du vill avsluta programmet? (y/n): ");
        var option = Console.ReadLine() ?? "";

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);

        }
        else
        {
            ShowMainMenu();
        }
    }

    private void MenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"*** {title} ***");
        Console.WriteLine();
    }
}
