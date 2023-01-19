using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class TagRepository : Repository<Tag>
{
    private readonly SqlConnection _connection;
    public TagRepository(SqlConnection connection) : base(connection)
    {
        _connection = connection;
    }

    public List<Tag> GetWithPosts()
    {
        var query = @"
        SELECT
            [Tag].*,
            [Post].*
        FROM 
            [Tag]
            LEFT JOIN [PostTag] ON [Tag].[Id] = [PostTag].[TagId]
            LEFT JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]";
        var tags = new List<Tag>();
        var rows = _connection.Query<Tag, Post, Tag>(query,
        (tag, post) =>
        {
            var t = tags.FirstOrDefault(x => x.Id == tag.Id);
            if (t == null)
            {
                t = tag;
                if (post != null)
                    t.Posts.Add(post);
                tags.Add(t);
            }
            else
            {
                t.Posts.Add(post);
            }
            return t;
        }, splitOn: "Id");
        return tags;
    }
}