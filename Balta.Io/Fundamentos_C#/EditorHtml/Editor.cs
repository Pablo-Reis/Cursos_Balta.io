using System.Text;
using System.IO;
using System.Threading;

namespace EditorHtml
{
    public static class Editor
    {

        public static void Show()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("================MODO EDITOR===============");
            Console.WriteLine("------------------------------------------");
            Start();
        }
        static void Start()
        {
            StringBuilder file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("-------------------------------");

            Console.WriteLine("Deseja salvar o arquivo?\n1 - Sim  |  2 - Não");
            short salvarArquivo = short.Parse(Console.ReadLine());
            if (salvarArquivo == 1)
            {
                if (Salvar(file))
                {
                    Console.WriteLine("Arquivo salvo com sucesso!");
                    Thread.Sleep(2500);
                    Viewer.Show(file.ToString());
                }
            }
            Viewer.Show(file.ToString());
            //Menu.Show();
        }
        static bool Salvar(StringBuilder file)
        {
            bool success = false;
            Console.WriteLine("Qual o local para salvar o arquivo?");
            string path = Console.ReadLine();
            using (StreamWriter writer = new(path))
            {
                writer.Write(file.ToString());
                success = true;
            }
            return success;
        }
    }
}