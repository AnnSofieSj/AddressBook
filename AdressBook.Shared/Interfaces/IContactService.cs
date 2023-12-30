

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
    /// <returns>Returns all contacts in list or null! if it fails </returns>
    IEnumerable<IContact> GetContactsFromList();

    /// <summary>
    /// Get one contact from list
    /// </summary>
    /// <param name="email">Enter emailadress to get detailed information about contact</param>
    /// <returns>Returns detailed information about contact if successfull or null! if it fails or contact dont exists</returns>
    IContact GetContactFromList(string email);

    /// <summary>
    /// Removes a contact from list (--------- Rätt sätt???------)
    /// </summary>
    /// <param name="contact"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    bool RemoveContactFromList(string email);
}
