namespace Desafio3;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        try
        {
            Console.WriteLine("Qual combustível compensa mais? Preencha os campos abaixo para descobrir!");
            Console.WriteLine("---------------------------------------------");
            Console.Write("Valor do álcool: ");
            decimal alcool = decimal.Parse(Console.ReadLine().Replace(',', '.'));
            Console.Write("Valor da gasolina: ");
            decimal gasolina = decimal.Parse(Console.ReadLine().Replace(',', '.'));
            var relacao = alcool / gasolina;
            Console.WriteLine($"A razão do preço do álcool para o preço da gasolina é {relacao.ToString("N2")}({relacao.ToString("P0")})");
            Console.WriteLine((relacao * 100) <= 72 ? "Usar álcool é mais econômico!" : "Usar gasolina é mais econômico!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Tipo incorreto de dado! Tente novamente..");
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ocorreu um erro durante a execução conforme a mensagem: '{e.Message}'");
        }
    }
}