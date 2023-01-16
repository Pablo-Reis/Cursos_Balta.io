using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.UserScreens;

public static class UpdateUserScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Atualizar usuário----------------");
        try
        {
            System.Console.Write("Digite o id do usuário que deseja atualizar: ");
            var id = int.Parse(Console.ReadLine());
            var repository = new Repository<User>(Database.Connection);
            var user = repository.Get(id);
            if (user is null)
            {
                Console.WriteLine("Usuário não encontrado!");
                Console.ReadKey();
                MenuUserScreen.Load();
            }
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
            Update(new User
            {
                Id = id,
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
    public static void Update(User user)
    {
        try
        {
            var repository = new Repository<User>(Database.Connection);
            repository.Update(user);
            Console.WriteLine("Usuário atualizado com sucesso!");
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Erro conforme mensagem: {e.Message}");
        }


    }
}