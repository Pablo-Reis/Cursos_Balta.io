namespace Desafio2;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("Informe sua altura: ");
        if (float.TryParse(Console.ReadLine(), out float altura))
        {
            Console.Write("Informe seu peso: ");
            if (float.TryParse(Console.ReadLine(), out float peso))
            {
                CalcularIMC(peso, altura);
            }
            else
            {
                Console.WriteLine("Tipo de dado incorreto!");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Tipo de dado incorreto!");
            Console.ReadKey();
        }
    }
    static void CalcularIMC(float peso, float altura)
    {
        var imc = peso / (Math.Pow(altura, 2));
        Console.WriteLine($"Seu IMC é {imc.ToString("F2")}");

        if (imc < 16) Console.WriteLine("Magreza Grau III");
        if (imc >= 16 && imc <= 16.9) Console.WriteLine("Magreza Grau II");
        if (imc >= 17 && imc <= 18.4) Console.WriteLine("Magreza Grau I");
        if (imc > 18.5 && imc <= 24.9) Console.WriteLine("Eutrofia");

        if (imc >= 25 && imc <= 29.9)
        {
            Console.WriteLine("Sobrepeso");
            Console.WriteLine("Risco: Aumentado");
        }
        if (imc >= 30 && imc <= 34.9)
        {
            Console.WriteLine("Obesidade Grau I");
            Console.WriteLine("Risco: Moderado");
        }
        if (imc >= 35 && imc <= 40)
        {
            Console.WriteLine("Obesidade Grau II");
            Console.WriteLine("Risco: Grave");
        }
        if (imc > 40)
        {
            Console.WriteLine("Obesidade Grau III");
            Console.WriteLine("Risco: Muito grave");
        }
        Console.ReadKey();
    }
}
