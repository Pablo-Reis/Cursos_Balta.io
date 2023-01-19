using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.TagScreen;

public static class UpdateTagScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Atualizar tag----------------");
        try
        {
            System.Console.Write("Digite o id da tag que deseja atualizar: ");
            var id = int.Parse(Console.ReadLine());
            var repository = new Repository<Tag>(Database.Connection);
            var tag = repository.Get(id);
            if (tag is null)
            {
                Console.WriteLine("Tag não encontrada!");
                Console.ReadKey();
                Program.Load();
            }
            System.Console.Write("Nome: ");
            var name = Console.ReadLine();
            System.Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Update(new Tag
            {
                Id = id,
                Name = name,
                Slug = slug
            });
        }
        catch (Exception e)
        {
            Console.Write($"Não foi possível atualizar a tag: {e.Message}");
        }
        Console.ReadKey();
        Program.Load();
    }
    public static void Update(Tag tag)
    {
        try
        {
            var repository = new Repository<Tag>(Database.Connection);
            repository.Update(tag);
            Console.WriteLine("Tag atualizada com sucesso!");
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Erro conforme mensagem: {e.Message}");
        }
    }
}