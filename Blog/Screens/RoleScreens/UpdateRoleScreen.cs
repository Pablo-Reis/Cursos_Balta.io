using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.RoleScreen;

public static class UpdateRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Atualizar perfil----------------");
        try
        {
            System.Console.Write("Digite o id do perfil que deseja atualizar: ");
            var id = int.Parse(Console.ReadLine());
            var repository = new Repository<Role>(Database.Connection);
            var role = repository.Get(id);
            if (role is null)
            {
                Console.WriteLine("Perfil não encontrado!");
                Console.ReadKey();
                Program.Load();
            }
            System.Console.Write("Nome: ");
            var name = Console.ReadLine();
            System.Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Update(new Role
            {
                Id = id,
                Name = name,
                Slug = slug
            });
        }
        catch (Exception e)
        {
            Console.Write($"Não foi possível atualizar perfil: {e.Message}");
        }
        Console.ReadKey();
        Program.Load();
    }
    public static void Update(Role role)
    {
        try
        {
            var repository = new Repository<Role>(Database.Connection);
            repository.Update(role);
            Console.WriteLine("Perfil atualizado com sucesso!");
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Erro conforme mensagem: {e.Message}");
        }
    }
}