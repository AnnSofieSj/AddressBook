using Contact = AdressBook.Shared.Models.Contact;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using AdressBook.Shared.Services;
using CommunityToolkit.Mvvm.Input;

namespace MobilApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ContactService _contactService;

    public MainViewModel(ContactService contactService)
    {
        _contactService = contactService;       
    }

    [ObservableProperty]
    private Contact _registrationForm = new();

    [ObservableProperty]
    private ObservableCollection<Contact> _contactList = [];

    [RelayCommand]
    public void AddContactToList()
    {
        if(RegistrationForm != null && !string.IsNullOrWhiteSpace(RegistrationForm.Email))
        {
            var result = _contactService.AddContactToList(RegistrationForm);
            if (result)
            {
                ContactList = (ObservableCollection<Contact>)_contactService.GetContactsFromList();
            }
                    
        }
    }

    public void UpdateContactList()
    {
        ContactList = new ObservableCollection<Contact>(_contactService.Contacts.Select(contact => contact).ToList());  // Här var jag sist och grejade, vill sig inte riktigt och hinner inte mer nu
    }
}
