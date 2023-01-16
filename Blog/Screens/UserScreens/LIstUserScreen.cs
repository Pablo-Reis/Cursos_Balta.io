using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.UserScreens;

public static class ListUserScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Listar usuários----------------");
        List();
        Console.ReadKey();
        Program.Load();
    }
    private static void List()
    {
        var repository = new Repository<User>(Database.Connection);
        var users = repository.Get();
        foreach (var item in users)
        {
            System.Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}