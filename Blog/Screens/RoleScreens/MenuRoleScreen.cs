namespace Blog.Screens.RoleScreen;

public static class MenuRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("GESTÃO DE PERFIS\n-------------------------------------");
        Console.WriteLine("\nSelecione a opção que deseja:");
        Console.WriteLine("1 - Criar perfil\n2 - Listar perfis\n3 - Atualizar perfil\n4 - Remover perfil");
        if (short.TryParse(Console.ReadLine(), out short option))
        {
            switch (option)
            {
                case 1:
                    CreateRoleScreen.Load();
                    break;
                case 2:
                    ListRoleScreen.Load();
                    break;
                case 3:
                    UpdateRoleScreen.Load();
                    break;
                case 4:
                    DeleteRoleScreen.Load();
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

