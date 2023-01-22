using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ReportsScreen;

public static class GetPostsWithTags
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------POSTS COM TAGS------------");
        var repository = new PostRepository(Database.Connection);
        var posts = repository.GetWithTags();
        foreach (var post in posts)
        {
            System.Console.WriteLine($"POST: {post.Title}");
            foreach (var item in post.Tags)
            {
                System.Console.WriteLine($"- {item.Name}");
            }
        }
        Console.ReadKey();
        Program.Load();
    }
}