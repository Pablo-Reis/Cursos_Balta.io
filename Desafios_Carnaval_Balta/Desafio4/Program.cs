using System.Globalization;

namespace Desafio4;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("Valor final da compra: ");
        decimal.TryParse(Console.ReadLine(), out decimal valorFinal);
        Console.Write("Pagamento: ");
        decimal.TryParse(Console.ReadLine(), out decimal valorRecebido);
        if (valorFinal == valorRecebido)
        {
            Console.WriteLine("Não precisa de troco!");
            return;
        }
        decimal troco = valorRecebido - valorFinal;
        if (troco < 0)
        {
            Console.WriteLine($"O cliente ainda precisa pagar {Math.Abs(troco).ToString("C")}!");
            return;
        }
        int qtdeNotas = 0;
        Console.WriteLine("Troco:");
        var valoresNotas = new int[] { 200, 100, 50, 20, 10, 5, 2 };
        for (int i = 0; i < valoresNotas.Count(); i++)
        {
            if (troco >= valoresNotas[i])
            {
                qtdeNotas = (int)troco / valoresNotas[i];
                if (qtdeNotas == 1) Console.WriteLine($"- {qtdeNotas} nota de {valoresNotas[i]} reais".PadLeft(5));
                else Console.WriteLine($"- {qtdeNotas} notas de {valoresNotas[i]} reais".PadLeft(5));
                troco %= valoresNotas[i];
            }
        }
        if (troco > 0 && troco < 2) Console.WriteLine($"Sobraram {troco.ToString("C")} para serem distribuídos como moedas");
    }
}
