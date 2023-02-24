using System.Text;

namespace Desafio7;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Digite o tamanho da lista fibonacci que deseja (mínimo 2): ");
        int.TryParse(Console.ReadLine(), out int valorDigitado);
        if (valorDigitado < 2)
        {
            Console.WriteLine("O valor precisa ser pelo menos 2");
            Console.ReadKey();
            return;
        }
        Console.Clear();
        var fibonacciValues = Fibonacci(valorDigitado);
        StringBuilder fibonacciText = new();
        for (int line = 0; line < valorDigitado; line++)
        {
            for (int j = 0; j <= line; j++)
            {
                if (fibonacciValues[j].ToString().Length < 5)
                {
                    fibonacciText.Append(fibonacciValues[j].ToString().PadRight(6, ' '));
                    continue;
                }
                fibonacciText.Append(fibonacciValues[j] + "  ");
            }
            //Console.Write("\n");
            fibonacciText.Append("\n");
        }
        Console.WriteLine(fibonacciText.ToString());

    }
    static IList<int> Fibonacci(int range)
    {
        List<int> values = new() { 0, 1 };

        for (int i = 2; i < range; i++)
        {
            values.Add(values[i - 1] + values[i - 2]);
        }
        return values;
    }
}
