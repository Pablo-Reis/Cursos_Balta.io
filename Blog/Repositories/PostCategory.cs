using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class PostRepository : Repository<Post>
{
    private readonly SqlConnection _connection;
    public PostRepository(SqlConnection connection) : base(connection)
    {
        _connection = connection;
    }

    public IEnumerable<Post> GetFromCategory(int categoryId)
    {
        var query = @"
        SELECT
            [Post].*,
            [Category].*
        FROM 
            [Post]
            LEFT JOIN [Category] ON [Post].[CategoryId] = [Category].[Id]";
        var posts = _connection.Query<Post, Category, Post>(query,
        (post, category) =>
        {
            post.Category = category;
            return post;
        },
        splitOn: "Id");
        return posts.Where<Post>(p => p.Category.Id == categoryId);
    }

    public IEnumerable<Post> GetWithCategory()
    {
        var query = @"
        SELECT
            [Post].*,
            [Category].*
        FROM 
            [Post]
            LEFT JOIN [Category] ON [Post].[CategoryId] = [Category].[Id]";
        var posts = _connection.Query<Post, Category, Post>(query,
        (post, category) =>
        {
            post.Category = category;
            return post;
        },
        splitOn: "Id");
        return posts;
    }
    public List<Post> GetWithTags()
    {
        var query = @"
        SELECT
            [Post].*,
            [Tag].*,
            [Category].*
        FROM
            [Post]
            LEFT JOIN [PostTag] ON [Post].[Id] = [PostTag].[PostId]
            LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]
            LEFT JOIN [Category] ON [Post].[CategoryId] = [Category].[Id]";
        var posts = new List<Post>();
        var pts = _connection.Query<Post, Tag, Category, Post>(query,
        (post, tag, category) =>
        {
            var pts = posts.Where<Post>(p => p.Id == post.Id).FirstOrDefault();
            if (pts is null)
            {
                pts = post;
                if (category is not null && tag is not null)
                {
                    pts.Category = category;
                    pts.Tags.Add(tag);
                }
                posts.Add(pts);
            }
            else
            {
                pts.Category = category;
                pts.Tags.Add(tag);
            }
            return post;
        },
        splitOn: "Id");
        return posts;
    }
}