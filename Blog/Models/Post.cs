using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("[Post]")]
public class Post
{
    public Post()
    {
        Category = new();
        Tags = new();
    }
    public int Id { get; set; }
    public string Title { get; set; }
    [Write(false)]
    public Category Category { get; set; }
    [Write(false)]
    public List<Tag> Tags { get; set; }
}