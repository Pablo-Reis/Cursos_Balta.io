using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.RoleScreen;

public static class CreateRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Cadastrar perfil----------------");
        try
        {
            System.Console.Write("Nome do perfil: ");
            var name = Console.ReadLine();
            System.Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Create(new Role
            {
                Id = 0,
                Name = name,
                Slug = slug
            });
        }
        catch (Exception e)
        {
            Console.Write($"Não foi possível cadastrar usuário: {e.Message}");
        }
        Console.ReadKey();
        Program.Load();
    }
    private static void Create(Role role)
    {
        var repository = new Repository<Role>(Database.Connection);
        try
        {
            repository.Create(role);
            Console.WriteLine("Perfil cadastrado com sucesso!");
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Erro conforme: {e.Message}");
        }
    }
}