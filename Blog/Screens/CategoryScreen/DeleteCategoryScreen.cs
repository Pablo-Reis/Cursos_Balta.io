using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreen;

public static class DeleteCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        System.Console.WriteLine("--------------Deletar categoria----------------");
        try
        {
            System.Console.Write("Digite o id da categoria que deseja deletar: ");
            var id = int.Parse(Console.ReadLine());
            Delete(id);
        }
        catch (Exception e)
        {
            Console.Write($"Não foi possível deletar categoria: {e.Message}");
        }
        Console.ReadKey();
        Program.Load();
    }
    public static void Delete(int id)
    {
        try
        {
            var repository = new Repository<Category>(Database.Connection);
            var category = repository.Get(id);
            if (category is not null)
            {
                repository.Delete(category);
                Console.WriteLine("Categoria deletada com sucesso!");
            }
            else System.Console.WriteLine("Categoria não encontrado!");

        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Erro conforme mensagem: {e.Message}");
        }
    }
}