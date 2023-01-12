using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog;
class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=Bubita111316;Trusted_Connection=false;TrustServerCertificate=true";
    static void Main(string[] args)
    {
        Console.ReadKey();
    }

}
