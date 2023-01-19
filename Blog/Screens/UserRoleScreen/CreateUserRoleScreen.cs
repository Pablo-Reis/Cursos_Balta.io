using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Screens.UserRoleScreen;

public static class CreateUserRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        try
        {
            System.Console.Write("ID do usuário que deseja vincular: ");
            var userId = int.Parse(Console.ReadLine());
            var user = new Repository<User>(Database.Connection).Get(userId);
            if (user is null)
            {
                System.Console.WriteLine("Usuário não encontrado!");
                Console.ReadKey();
                Load();
            }
            System.Console.Write("ID do perfil que deseja adicionar ao usuário: ");
            var roleId = int.Parse(Console.ReadLine());
            var role = new Repository<Role>(Database.Connection).Get(roleId);
            if (role is null)
            {
                System.Console.WriteLine("Perfil não encontrado!");
                Console.ReadKey();
                Load();
            }
            Link(user.Id, role.Id);

        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Houve um erro ao vincular usuário ao perfil: {e.Message}");
            Console.ReadKey();
            Program.Load();
        }
    }

    private static void Link(int idUser, int idRole)
    {
        var query = "INSERT INTO [UserRole] ([UserId], [RoleId]) VALUES (@UserId, @RoleId)";
        var rows = Database.Connection.Execute(query, new
        {
            UserId = idUser,
            Roleid = idRole
        });
        if (rows > 0) System.Console.WriteLine("Vínculo feito com sucesso!");
        else
        {
            System.Console.WriteLine("Não foi possível incluir vínculo");
        }
        Console.ReadKey();
        Program.Load();
    }
}