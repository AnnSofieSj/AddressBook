
using AdressBook.Shared.Interfaces;
using AdressBook.Shared.Models;
using AdressBook.Shared.Services;
using Moq;

namespace ContactApp.Tests;

public class ContactService_Tests
{
    [Fact]
    public void AddToListShould_AddOneContactToContactList_ThenReturnTrue()
    {
        // Arrange
        IContact contact = new Contact { FirstName = "Test", LastName = "Testson", Email = "test@domain.com"};

        var mockFileService = new Mock<IFileService>();
        IContactService contactService = new ContactService(mockFileService.Object);
        

        // Act

        bool result = contactService.AddContactToList(contact);

        // Assert
        Assert.True(result);
    }
}
