namespace EditorHtml
{
    public static class Menu
    {
        static int column = 30;
        static int line = 15;
        public static void Show()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            DrawScreen();
            ShowOption();
            short option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);
        }
        static void DrawScreen()
        {
            DrawTopAndBottomBorders();
            DrawAsideBorders();
            DrawTopAndBottomBorders();
        }

        static void ShowOption()
        {
            Console.SetCursorPosition(3, 2);
            Console.Write("EDITOR HTML");
            Console.SetCursorPosition(3, 3);
            Console.Write("===================");
            Console.SetCursorPosition(3, 4);
            Console.Write("Selecione uma opção abaixo");
            Console.SetCursorPosition(3, 6);
            Console.Write("1 - Criar novo arquivo");
            Console.SetCursorPosition(3, 7);
            Console.Write("2 - Abrir");
            Console.SetCursorPosition(3, 9);
            Console.Write("0 - Sair do programa");
            Console.SetCursorPosition(3, 10);
            Console.Write("Opção: ");
        }

        static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1: Editor.Show(); break;
                case 2: Console.Write("View"); break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0); break;
                    }
                default: Show(); break;

            }
        }

        static void DrawTopAndBottomBorders()
        {
            Console.Write("+");
            for (int col = 0; col < column; col++)
            {
                Console.Write("-"); //Adicionando linhas do top/bottom
            }
            Console.Write("+");
            Console.Write("\n"); //Quebrando linha
        }
        static void DrawAsideBorders()
        {
            for (int lineAtual = 0; lineAtual < line; lineAtual++)
            {
                Console.Write("|");
                for (int col = 0; col < column; col++)
                    Console.Write(" ");
                Console.Write("|");
                Console.Write("\n");
            }
        }
    }
}