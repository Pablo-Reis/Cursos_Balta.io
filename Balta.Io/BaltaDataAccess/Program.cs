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
            //ExecuteReadProcedure(connection);
            //ListCategories(connection);
            //ExecuteScalar(connection);
            //ReadView(connection);
            //OneToOne(connection);
            //OneToMany(connection);
            //QueryMultiple(connection);
            //SelectIn(connection);
            //Like(connection);
            Transaction(connection);
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

    static void ExecuteScalar(SqlConnection connection)
    {
        var category = new Category();
        category.Title = "Amazon AWS3";
        category.Url = "amazon3";
        category.Description = "Categoria destinada a serviços do AWS3";
        category.Order = 10;
        category.Summary = "AWS Cloud3";
        category.Featured = false;
        var insertUrl = @"INSERT INTO 
                [Category]
                OUTPUT inserted.[Id]
            VALUES(
                NEWID(), 
                @Title, 
                @url, 
                @Summary, 
                @Order, 
                @Description, 
                @Featured
                )";
        var id = connection.ExecuteScalar<Guid>(insertUrl, new
        {
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured
        });
        Console.WriteLine($"A categoria inserida foi {id}");
    }
    static void ReadView(SqlConnection connection)
    {
        var sql = "SELECT * FROM [vwCourses]";

        var courses = connection.Query(sql);
        foreach (var course in courses)
        {
            Console.WriteLine($"{course.Id} - {course.Title}");
        }
    }
    static void OneToOne(SqlConnection connection)
    {
        var sql = @"SELECT * FROM [CareerItem]
            INNER JOIN [Course] ON [CareerItem].CourseId = [Course].[Id]";
        var items = connection.Query<CareerItem, Course, CareerItem>(sql, (careerItem, course) => { careerItem.Course = course; return careerItem; }, splitOn: "Id");
        foreach (var item in items)
        {
            Console.WriteLine(item.Title);
            Console.WriteLine($"- {item.Course.Title}");
        }
    }
    static void OneToMany(SqlConnection connection)
    {
        var sql = @"
        SELECT
            [Career].[Id],
            [Career].[Title],
            [CareerItem].[CareerId],
            [CareerItem].[Title]
        FROM
            [Career]
        INNER JOIN
            [CareerItem]
            ON [Career].[Id] = [CareerItem].[CareerId]
        ORDER BY [Career].[Title]";
        var careers = new List<Career>();
        var items = connection.Query<Career, CareerItem, Career>(sql, (career, item) =>
        {
            var car = careers.Where<Career>(x => x.Id == career.Id).FirstOrDefault(); //Se retornar nulo, significa que a carreira ainda não foi adicionada
            if (car is null)
            {
                car = career;
                car.Items.Add(item);
                careers.Add(car);
            }
            else
            {
                car.Items.Add(item);
            }
            return career;
        },
            splitOn: "CareerId");
        foreach (var career in careers)
        {
            Console.WriteLine(career.Title);
            foreach (var item in career.Items)
            {
                Console.WriteLine($"- {item.Title}");
            }
        }
    }
    static void QueryMultiple(SqlConnection connection)
    {
        var query = "SELECT [Id], [Title] FROM [Category]; SELECT [Id], [Title] FROM [Course]";
        using (var multiple = connection.QueryMultiple(query))
        {
            var categories = multiple.Read<Category>();
            var courses = multiple.Read<Course>();
            foreach (var category in categories)
            {
                Console.WriteLine($"- {category.Title}");
            }
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Title}");
            }
        }
    }
    static void SelectIn(SqlConnection connection)
    {
        var query = "SELECT [Id], [Title] FROM [Category] WHERE [Id] IN @Id";
        var categories = connection.Query<Category>(query, new
        {
            Id = new[]{
                "af3407aa-11ae-4621-a2ef-2028b85507c4",
                "c2c9f673-76b9-4cfa-902c-223fc9fb420b"
            }
        });
        foreach (var category in categories)
        {
            System.Console.WriteLine(category.Title);
        }
    }
    static void Like(SqlConnection connection)
    {
        var query = "SELECT [Id], [Title] FROM [Course] WHERE [Title] LIKE @Title";
        var courses = connection.Query<Course>(query, new { Title = "%backend%" });
        foreach (var course in courses)
        {
            System.Console.WriteLine(course.Title);
        }
    }
    static void Transaction(SqlConnection connection)
    {
        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Title = "Categoria teste que não quero";
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
        connection.Open();
        using (var transaction = connection.BeginTransaction())
        {
            var rows = connection.Execute(insertUrl, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            }, transaction);
            //transaction.Rollback(); PADRÃO
            transaction.Commit();
            Console.WriteLine($"{rows} linhas inseridas!");
        }
    }
}
