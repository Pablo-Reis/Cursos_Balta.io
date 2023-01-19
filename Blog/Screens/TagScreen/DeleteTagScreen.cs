using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreen;

public static class DeleteTagScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Deletar tag----------------");
        try
        {
            System.Console.Write("Digite o id da tag que deseja deletar: ");
            var id = int.Parse(Console.ReadLine());
            Delete(id);
        }
        catch (Exception e)
        {
            Console.Write($"Não foi possível deletar a tag: {e.Message}");
        }
        Console.ReadKey();
        Program.Load();
    }
    public static void Delete(int id)
    {
        try
        {
            var repository = new Repository<Tag>(Database.Connection);
            var tag = repository.Get(id);
            if (tag is not null)
            {
                repository.Delete(tag);
                Console.WriteLine("Tag deletada com sucesso!");
            }
            else System.Console.WriteLine("Tag não encontrado!");

        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Erro conforme mensagem: {e.Message}");
        }
    }
}