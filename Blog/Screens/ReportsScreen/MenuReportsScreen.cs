namespace Blog.Screens.ReportsScreen;

public static class MenuReportsScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("RELATÓRIOS\n-------------------------------------");
        Console.WriteLine("\nSelecione a opção que deseja:");
        Console.WriteLine("1 - Relátório de usuários\n2 - Categorias com quantidade de posts\n3 - Tags com quantidade de posts\n4 - Posts de uma categoria\n5 - Posts com suas categorias\n6 - Post com suas tags");
        if (short.TryParse(Console.ReadLine(), out short option))
        {
            switch (option)
            {
                case 1:
                    GetUserWithRoles.Load();
                    break;
                case 2:
                    GetCategoriesWithPosts.Load();
                    break;
                case 3:
                    GetTagsWithPosts.Load();
                    break;
                case 4:
                    GetPostsFromCategory.Load();
                    break;
                case 5:
                    GetPostsWithCategory.Load();
                    break;
                case 6:
                    GetPostsWithTags.Load();
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

