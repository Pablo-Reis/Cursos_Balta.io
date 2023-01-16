using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.RoleScreen;

public static class ListRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Listar perfis----------------");
        List();
        Console.ReadKey();
        Program.Load();
    }
    private static void List()
    {
        var repository = new Repository<Role>(Database.Connection);
        var roles = repository.Get();
        foreach (var item in roles)
        {
            System.Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}