using System.Text;
using Blog.Repositories;

namespace Blog.Screens.ReportsScreen;

public static class GetCategoriesWithPosts
{
    public static void Load()
    {
        var categories = new CategoryRepository(Database.Connection).GetWithPosts();
        foreach (var category in categories)
        {
            System.Console.WriteLine($"{category.Name} - {category.Posts.Count}");
        }
    }
}