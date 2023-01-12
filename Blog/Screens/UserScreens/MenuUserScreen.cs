using Blog.Screens.Enums;

namespace Blog.Screens.UserScreens;

public static class MenuUserScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("GESTÃO DE USUÁRIOS\n-------------------------------------");
        Console.WriteLine("\nSelecione a opção que deseja:");
        Console.WriteLine("1 - Criar usuário\n2 - Listar usuários");
        if (short.TryParse(Console.ReadLine(), out short option))
        {
            switch ((EMenuOptions)option)
            {
                case EMenuOptions.Cadastrar:

                    break;
                case EMenuOptions.Listar:

                    break;
                default:
                    Load();
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

