
using ContactApp.Interfaces;
using ContactApp.Services;

IMenuService menuService = new MenuService();
menuService.ShowMainMenu();

Console.ReadKey(); 