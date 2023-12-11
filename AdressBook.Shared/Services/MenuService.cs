
using AdressBook.Shared.Interfaces;

namespace AdressBook.Shared.Services;

public class MenuService : IMenuService
{
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
        throw new NotImplementedException();
    }

    private void ShowAllContacts()
    {
        throw new NotImplementedException();
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

