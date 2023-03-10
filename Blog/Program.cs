using Blog.Screens.CategoryScreen;
using Blog.Screens.ReportsScreen;
using Blog.Screens.RoleScreen;
using Blog.Screens.TagScreen;
using Blog.Screens.UserRoleScreen;
using Blog.Screens.UserScreens;
using Microsoft.Data.SqlClient;

namespace Blog;
class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=Bubita111316;Trusted_Connection=false;TrustServerCertificate=true";
    static void Main(string[] args)
    {
        Database.Connection = new SqlConnection(CONNECTION_STRING);
        Database.Connection.Open();
        Load();
        Console.ReadKey();
        Database.Connection.Close();
    }
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Meu Blog");
        Console.WriteLine("-----------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 - Gestão de usuário");
        Console.WriteLine("2 - Gestão de perfil");
        Console.WriteLine("3 - Gestão de categoria");
        Console.WriteLine("4 - Gestão de tag");
        Console.WriteLine("5 - Vincular perfil/usuário");
        Console.WriteLine("6 - Vincular post/tag");
        Console.WriteLine("7 - Relatórios");
        Console.WriteLine("8 - Sair");
        Console.WriteLine();
        Console.WriteLine();
        try
        {
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;

                case 2:
                    MenuRoleScreen.Load();
                    break;

                case 3:
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:
                    CreateUserRoleScreen.Load();
                    break;

                case 6:
                    CreatePostTagScreen.Load();
                    break;

                case 7:
                    MenuReportsScreen.Load();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default: Load(); break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Erro conforme mensagem: {e.Message}");
        }

    }
}
