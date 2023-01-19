using System.Text;
using Blog.Repositories;

namespace Blog.Screens.ReportsScreen;

public static class GetUserWithRoles
{
    public static void Load()
    {
        var users = new UserRepository(Database.Connection).GetWithRoles();
        foreach (var user in users)
        {
            System.Console.Write($"{user.Name} - {user.Email}");
            foreach (var item in user.Roles)
            {
                System.Console.Write($", {item.Name}");
            }
            Console.WriteLine();
        }
    }
}