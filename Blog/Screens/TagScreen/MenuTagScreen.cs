namespace Blog.Screens.TagScreen;

public static class MenuTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("GESTÃO DE TAGS\n-------------------------------------");
        Console.WriteLine("\nSelecione a opção que deseja:");
        Console.WriteLine("1 - Criar tag\n2 - Listar tags\n3 - Atualizar tag\n4 - Remover tag");
        if (short.TryParse(Console.ReadLine(), out short option))
        {
            switch (option)
            {
                case 1:
                    CreateTagScreen.Load();
                    break;
                case 2:
                    ListTagScreen.Load();
                    break;
                case 3:
                    UpdateTagScreen.Load();
                    break;
                case 4:
                    DeleteTagScreen.Load();
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

