using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreen;

public static class CreateTagScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Cadastrar tag----------------");
        try
        {
            System.Console.Write("Nome da tag: ");
            var name = Console.ReadLine();
            System.Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Create(new Tag
            {
                Id = 0,
                Name = name,
                Slug = slug
            });
        }
        catch (Exception e)
        {
            Console.Write($"Não foi possível cadastrar a tag: {e.Message}");
        }
        Console.ReadKey();
        Program.Load();
    }
    private static void Create(Tag tag)
    {
        var repository = new Repository<Tag>(Database.Connection);
        try
        {
            repository.Create(tag);
            Console.WriteLine("Tag cadastrada com sucesso!");
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Erro conforme: {e.Message}");
        }
    }
}