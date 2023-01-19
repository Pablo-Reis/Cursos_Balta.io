using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class CategoryRepository : Repository<Category>
{
    private readonly SqlConnection _connection;
    public CategoryRepository(SqlConnection connection) : base(connection)
    {
        _connection = connection;
    }

    public List<Category> GetWithPosts()
    {
        var query = @"
        SELECT
            [Category].*,
            [Post].*
        FROM 
            [Category]
            LEFT JOIN [Post] ON [Category].[Id] = [Post].[CategoryId]";
        var categories = new List<Category>();
        var items = _connection.Query<Category, Post, Category>(query,
        (category, post) =>
        {
            var cat = categories.FirstOrDefault(x => x.Id == category.Id);
            if (cat == null)
            {
                cat = category;
                if (post != null)
                    cat.Posts.Add(post);
                categories.Add(cat);
            }
            else
            {
                cat.Posts.Add(post);
            }
            return category;
        }, splitOn: "Id");
        return categories;
    }
}