
using AdressBook.Shared.Interfaces;
using AdressBook.Shared.Services;
using ContactApp.Interfaces;
using ContactApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services => 
{
    services.AddSingleton<IFileService, FileService>();
    services.AddSingleton<IContactService, ContactService>();
    services.AddSingleton<IMenuService, MenuService>();
}).Build();

builder.Start();
Console.Clear();

IMenuService menuService = builder.Services.GetRequiredService<IMenuService>();
menuService.ShowMainMenu();

Console.ReadKey(); 