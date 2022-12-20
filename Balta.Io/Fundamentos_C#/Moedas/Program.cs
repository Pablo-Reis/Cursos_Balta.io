using System.Globalization;
namespace Moedas
{
    class program
    {
        static void Main()
        {
            Console.Clear();
            decimal valor = 10.25m;

            Console.WriteLine(valor.ToString(
                "C", //Existem vários tipos de formatações, mas os mais usados são C - coin/currency, N - Number e G - Generic
                CultureInfo.CreateSpecificCulture("pt-BR")
            ));

            Console.WriteLine(Math.Round(valor)); //Remove decimais
            Console.WriteLine(Math.Ceiling(valor)); //Arredonda para cima
            Console.WriteLine(Math.Floor(valor)); //Arredonda para baixo
        }
    }
}