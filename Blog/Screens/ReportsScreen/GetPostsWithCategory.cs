using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ReportsScreen;

public static class GetPostsWithCategory
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------POSTS COM CATEGORIA------------");
        var repository = new PostRepository(Database.Connection);
        var posts = repository.GetWithCategory();
        foreach (var post in posts)
        {
            System.Console.WriteLine($"POST: {post.Title} - CATEGORIA: {post.Category.Name}");
        }
        Console.ReadKey();
        Program.Load();
    }
}