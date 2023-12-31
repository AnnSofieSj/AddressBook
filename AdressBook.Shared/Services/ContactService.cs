
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
        Contacts = GetContactsFromList().ToList();
    }


    public List<IContact> Contacts {get; private set;} = [];
    private readonly string _filePath = @"C:\eceducation\csharp-projects\addressbook\list.json";

  

    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!Contacts.Any(x => x.Email == contact.Email))
            {
                Contacts.Add(contact);

                string json = JsonConvert.SerializeObject(Contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

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
            var contact = Contacts.FirstOrDefault(x => x.Email == email);
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
                Contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return Contacts;
            }
            else { return Contacts; }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    
    public bool RemoveContactFromList(string email)
    {
       
        try
        {            
            GetContactsFromList();
            var contactRemove = Contacts.FirstOrDefault(x => x.Email == email);

            if (contactRemove != null)
            {
                Contacts.Remove(contactRemove);

                string json = JsonConvert.SerializeObject(Contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                var result = _fileService.SaveContentToFile(_filePath, json);
                return result;
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;

    }
}


   
