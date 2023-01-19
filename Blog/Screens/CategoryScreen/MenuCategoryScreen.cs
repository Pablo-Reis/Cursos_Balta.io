namespace Blog.Screens.CategoryScreen;

public static class MenuCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("GESTÃO DE CATEGORIAS\n-------------------------------------");
        Console.WriteLine("\nSelecione a opção que deseja:");
        Console.WriteLine("1 - Criar categoria\n2 - Listar categorias\n3 - Atualizar categoria\n4 - Remover categoria");
        if (short.TryParse(Console.ReadLine(), out short option))
        {
            switch (option)
            {
                case 1:
                    CreateCategoryScreen.Load();
                    break;
                case 2:
                    ListCategoryScreen.Load();
                    break;
                case 3:
                    UpdateCategoryScreen.Load();
                    break;
                case 4:
                    DeleteCategoryScreen.Load();
                    break;
                default:
                    Program.Load();
                    break;
            }
        }
        else
        {
            System.Console.WriteLine("Opção inválida!");
            Console.ReadKey();
            Load();
        }
    }
}

