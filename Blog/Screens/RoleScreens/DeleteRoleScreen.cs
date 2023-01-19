using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.RoleScreen;

public static class DeleteRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Deletar perfil----------------");
        try
        {
            System.Console.Write("Digite o id do perfil que deseja deletar: ");
            var id = int.Parse(Console.ReadLine());
            Delete(id);
        }
        catch (Exception e)
        {
            Console.Write($"Não foi possível deletar perfil: {e.Message}");
        }
        Console.ReadKey();
        Program.Load();
    }
    public static void Delete(int id)
    {
        try
        {
            var repository = new Repository<Role>(Database.Connection);
            var role = repository.Get(id);
            if (role is not null)
            {
                repository.Delete(role);
                Console.WriteLine("Perfil deletado com sucesso!");
            }
            else System.Console.WriteLine("Perfil não encontrado!");

        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Erro conforme mensagem: {e.Message}");
        }
    }
}