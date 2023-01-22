using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ReportsScreen;

public static class GetPostsFromCategory
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------POSTS DE UMA CATEGORIA------------");
        System.Console.Write("Digite o id da categoria: ");
        var categoryId = int.Parse(Console.ReadLine());
        var repository = new Repository<Category>(Database.Connection);
        var category = repository.Get(categoryId);
        if (category is null)
        {
            System.Console.WriteLine("Categoria não encontrada!");
            Console.ReadKey();
            Load();
        }
        var postRep = new PostRepository(Database.Connection);
        var posts = postRep.GetFromCategory(categoryId);
        System.Console.WriteLine($"Posts da categoria {category!.Name}");
        foreach (var post in posts)
        {
            System.Console.WriteLine($"-- {post.Title}");
        }
        Console.ReadKey();
        Program.Load();
    }
}