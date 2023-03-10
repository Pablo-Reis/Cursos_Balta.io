namespace Blog.Screens.UserScreens;

public static class MenuUserScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("GESTÃO DE USUÁRIOS\n-------------------------------------");
        Console.WriteLine("\nSelecione a opção que deseja:");
        Console.WriteLine("1 - Criar usuário\n2 - Listar usuários\n3 - Atualizar usuário\n4 - Remover usuário");
        if (short.TryParse(Console.ReadLine(), out short option))
        {
            switch (option)
            {
                case 1:
                    CreateUserScreen.Load();
                    break;
                case 2:
                    ListUserScreen.Load();
                    break;
                case 3:
                    UpdateUserScreen.Load();
                    break;
                case 4:
                    DeleteUserScreen.Load();
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

