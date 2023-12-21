
using AdressBook.Shared.Interfaces;
using AdressBook.Shared.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AdressBook.Shared.Services;

public class ContactService : IContactService
{
    private readonly IFileService _fileService;

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
        _contacts = GetContactsFromList().ToList();
    }


    private List<IContact> _contacts = [];
    private readonly string _filePath = @"C:\eceducation\csharp-projects\addressbook\list.json";

  

    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                var result = _fileService.SaveContentToFile(_filePath, json);
                return true; //true eller result?? Testet fungerar inte med result
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }


    public IContact GetContactFromList(string email)
    {
        try
        {
            GetContactsFromList();
            var contact = _contacts.FirstOrDefault(x => x.Email == email);
            return contact ??= null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }


    public IEnumerable<IContact> GetContactsFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contacts;
            }
            else { return _contacts; }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    
    public bool RemoveContactFromList(string email)
    {
       
        try
        {            
            GetContactsFromList();
            var contactRemove = _contacts.FirstOrDefault(x => x.Email == email);

            if (contactRemove != null)
            {
                _contacts.Remove(contactRemove);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                var result = _fileService.SaveContentToFile(_filePath, json);
                return result;
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;

    }
}


   
