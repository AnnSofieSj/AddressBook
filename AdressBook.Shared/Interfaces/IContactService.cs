

namespace AdressBook.Shared.Interfaces;

public interface IContactService
{
    /// <summary>
    /// Add a contact to contact list
    /// </summary>
    /// <param name="contact"> a contact of type IContact </param>
    /// <returns>Returns true if successfull or false if it fails or contact alredy exists</returns>
    bool AddContactToList(IContact contact);

    /// <summary>
    /// Get all contacts from list
    /// </summary>
    /// <returns></returns>
    IEnumerable<IContact> GetContactsFromList();

    /// <summary>
    /// Get one contact from list
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    IContact GetContactFromList(string email);
}
