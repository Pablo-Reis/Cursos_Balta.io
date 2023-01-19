using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.CategoryScreen;

public static class ListCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Listar categorias----------------");
        List();
        Console.ReadKey();
        Program.Load();
    }
    private static void List()
    {
        var repository = new Repository<Category>(Database.Connection);
        var categories = repository.Get();
        foreach (var item in categories)
        {
            System.Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}