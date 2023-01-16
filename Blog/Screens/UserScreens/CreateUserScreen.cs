using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.UserScreens;

public static class CreateUserScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Cadastrar usuário----------------");
        try
        {
            System.Console.Write("Nome: ");
            var name = Console.ReadLine();
            System.Console.Write("Email: ");
            var email = Console.ReadLine();
            System.Console.Write("Senha: ");
            var password = Console.ReadLine();
            System.Console.Write("Biografia: ");
            var bio = Console.ReadLine();
            System.Console.Write("Imagem: ");
            var image = Console.ReadLine();
            System.Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Create(new User
            {
                Id = 0,
                Name = name,
                Email = email,
                PasswordHash = password,
                Bio = bio,
                Image = image,
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
    private static void Create(User user)
    {
        var repository = new Repository<User>(Database.Connection);
        try
        {
            repository.Create(user);
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Erro conforme: {e.Message}");
        }
    }
}