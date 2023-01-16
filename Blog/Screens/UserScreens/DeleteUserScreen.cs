using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.UserScreens;

public static class DeleteUserScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Deletar usuário----------------");
        try
        {
            System.Console.Write("Digite o id do usuário que deseja deletar: ");
            var id = int.Parse(Console.ReadLine());
            Delete(id);
        }
        catch (Exception e)
        {
            Console.Write($"Não foi possível deletar usuário: {e.Message}");
        }
        Console.ReadKey();
        Program.Load();
    }
    public static void Delete(int id)
    {
        try
        {
            var repository = new Repository<User>(Database.Connection);
            var user = repository.Get(id);
            if (user is not null)
            {
                repository.Delete(user);
                Console.WriteLine("Usuário deletado com sucesso!");
            }
            else System.Console.WriteLine("Usuário não encontrado!");

        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Erro conforme mensagem: {e.Message}");
        }


    }
}