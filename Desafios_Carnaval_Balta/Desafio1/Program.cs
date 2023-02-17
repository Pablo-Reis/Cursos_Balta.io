while (true)
{
    Console.Clear();
    Console.WriteLine("***********DESAFIO 01 - CARNAVAL BALTA.IO***********\n");
    Console.WriteLine("""Digite um texto (Para sair, basta digitar "exit"): """);
    var inputText = Console.ReadLine().Trim();
    if (inputText.ToLower() == "exit") Environment.Exit(0);
    (int letterCount, int wordCount) = (inputText!.Length, inputText.Split(' ').Count());
    Console.WriteLine($"{letterCount} caracteres, {wordCount} palavras");
    Console.ReadKey();
}


