using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("[Post]")]
public class Post
{
    public Post()
    {
        Category = new();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
}