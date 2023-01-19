using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreen;

public static class CreateCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Cadastrar categoria----------------");
        try
        {
            System.Console.Write("Nome da categoria: ");
            var name = Console.ReadLine();
            System.Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Create(new Category
            {
                Id = 0,
                Name = name,
                Slug = slug
            });
        }
        catch (Exception e)
        {
            Console.Write($"Não foi possível cadastrar a categoria: {e.Message}");
        }
        Console.ReadKey();
        Program.Load();
    }
    private static void Create(Category category)
    {
        var repository = new Repository<Category>(Database.Connection);
        try
        {
            repository.Create(category);
            Console.WriteLine("Categoria cadastrada com sucesso!");
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Erro conforme: {e.Message}");
        }
    }
}