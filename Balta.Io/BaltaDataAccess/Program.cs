using Microsoft.Data.SqlClient;
using Dapper;
using BaltaDataAccess.Models;

namespace BaltaDataAccess;
class Program
{

    static void Main(string[] args)
    {
        const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=Bubita111316;Trusted_Connection=False; TrustServerCertificate=True;";

        using (var connection = new SqlConnection(connectionString))
        {
            // UpdateCategory(connection);
            //DeleteCategory(connection);
            // CreateCategory(connection);
            //CreateManyCategory(connection);
            //ExecuteProcedure(connection);
            ExecuteReadProcedure(connection);
            //ListCategories(connection);
        }
    }

    static void ListCategories(SqlConnection connection)
    {
        var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
        foreach (var item in categories)
        {
            System.Console.WriteLine($"{item.Id} - {item.Title}");
        }
    }
    static void CreateCategory(SqlConnection connection)
    {
        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Title = "Amazon AWS";
        category.Url = "amazon";
        category.Description = "Categoria destinada a serviços do AWS";
        category.Order = 8;
        category.Summary = "AWS Cloud";
        category.Featured = false;
        var insertUrl = @"INSERT INTO 
                [Category] 
            VALUES(
                @Id, 
                @Title, 
                @url, 
                @Summary, 
                @Order, 
                @Description, 
                @Featured
                )";
        var rows = connection.Execute(insertUrl, new
        {
            category.Id,
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured
        });
        Console.WriteLine($"{rows} linhas inseridas!");
    }
    static void UpdateCategory(SqlConnection connection)
    {
        var UpdateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
        var rows = connection.Execute(UpdateQuery, new
        {
            id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
            title = "Frontend 2022",
        });
        System.Console.WriteLine($"{rows} registros atualizados");
    }

    static void DeleteCategory(SqlConnection connection)
    {
        var DeleteQuery = "DELETE FROM [Category] WHERE [Title] = @title";
        var rows = connection.Execute(DeleteQuery, new
        {
            title = "Amazon AWS"
        });
        System.Console.WriteLine($"{rows} registros deletados");
    }

    static void CreateManyCategory(SqlConnection connection)
    {
        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Title = "Amazon AWS";
        category.Url = "amazon";
        category.Description = "Categoria destinada a serviços do AWS";
        category.Order = 8;
        category.Summary = "AWS Cloud";
        category.Featured = false;

        var category2 = new Category();
        category2.Id = Guid.NewGuid();
        category2.Title = "Categoria nova";
        category2.Url = "categoria-nova";
        category2.Description = "Categoria nova";
        category2.Order = 9;
        category2.Summary = "Categoria nova";
        category2.Featured = true;
        var insertUrl = @"INSERT INTO 
                [Category] 
            VALUES(
                @Id, 
                @Title, 
                @url, 
                @Summary, 
                @Order, 
                @Description, 
                @Featured
                )";
        var rows = connection.Execute(insertUrl, new[]{
            new {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            },
            new {
            category2.Id,
            category2.Title,
            category2.Url,
            category2.Summary,
            category2.Order,
            category2.Description,
            category2.Featured
            }
        }
        );
        Console.WriteLine($"{rows} linhas inseridas!");
    }

    static void ExecuteProcedure(SqlConnection connection)
    {
        var procedure = "[spDeleteStudent]";
        var pars = new { StudentId = "42513948-0fbc-4b5b-a04f-6996a3d42f5c" };
        var rows = connection.Execute(procedure, pars, commandType: System.Data.CommandType.StoredProcedure);
        Console.WriteLine($"{rows} registros executados");
    }

    static void ExecuteReadProcedure(SqlConnection connection)
    {
        var procedure = "[spGetCoursesByCategory]";
        var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
        var courses = connection.Query<Category>(procedure, pars, commandType: System.Data.CommandType.StoredProcedure);
        foreach (var course in courses)
        {
            Console.WriteLine($"{course.Id} - {course.Title}");
        }
    }
}
