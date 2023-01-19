using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.TagScreen;

public static class ListTagScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Listar tags----------------");
        List();
        Console.ReadKey();
        Program.Load();
    }
    private static void List()
    {
        var repository = new Repository<Tag>(Database.Connection);
        var tags = repository.Get();
        foreach (var item in tags)
        {
            System.Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}