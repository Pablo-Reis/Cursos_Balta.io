using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.CategoryScreen;

public static class UpdateCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Atualizar categoria----------------");
        try
        {
            System.Console.Write("Digite o id da categoria que deseja atualizar: ");
            var id = int.Parse(Console.ReadLine());
            var repository = new Repository<Category>(Database.Connection);
            var category = repository.Get(id);
            if (category is null)
            {
                Console.WriteLine("Categoria não encontrada!");
                Console.ReadKey();
                Program.Load();
            }
            System.Console.Write("Nome: ");
            var name = Console.ReadLine();
            System.Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Update(new Category
            {
                Id = id,
                Name = name,
                Slug = slug
            });
        }
        catch (Exception e)
        {
            Console.Write($"Não foi possível atualizar categoria: {e.Message}");
        }
        Console.ReadKey();
        Program.Load();
    }
    public static void Update(Category category)
    {
        try
        {
            var repository = new Repository<Category>(Database.Connection);
            repository.Update(category);
            Console.WriteLine("Categoria atualizado com sucesso!");
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Erro conforme mensagem: {e.Message}");
        }
    }
}