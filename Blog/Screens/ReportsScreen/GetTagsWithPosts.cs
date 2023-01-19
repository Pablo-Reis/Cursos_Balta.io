using Blog.Repositories;

namespace Blog.Screens.ReportsScreen;

public static class GetTagsWithPosts
{
    public static void Load()
    {
        var tags = new TagRepository(Database.Connection).GetWithPosts();
        foreach (var tag in tags)
        {
            System.Console.WriteLine($"{tag.Name} - {tag.Posts.Count}");
        }
    }
}