using System.Text;

namespace Desafio5;



class Program
{
    static void Main()
    {
        const int VALOR_MAXIMO_PERMITIDO = 999999999;
        Console.Clear();
        Console.Write("Digite o valor desejado: R$ ");
        var valorDigitado = Console.ReadLine().PadLeft(12, '0');
        if (int.Parse(valorDigitado.Substring(0, valorDigitado.IndexOf(','))) > VALOR_MAXIMO_PERMITIDO)
        {
            Console.WriteLine("Valor não suportado pelo sistema.");
            Console.ReadKey();
            Main();
        }
        Console.WriteLine(valorDigitado);
        StringBuilder numeroExtenso = new();
        if (int.Parse(valorDigitado.Substring(0, valorDigitado.IndexOf(','))) == 0)
        {
            numeroExtenso.Append("ZERO");
        }
        int casa = 3;
        for (int i = 0; i < 9; i++)
        {
            if (casa == 0) casa = 3;

            if (valorDigitado[i] != '0' && casa == 3) //Tratando centena
            {
                switch (valorDigitado[i])
                {
                    case '1':
                        if (valorDigitado[i + 1] == '0' && valorDigitado[i + 2] == '0') { numeroExtenso.Append("CEM"); break; }
                        numeroExtenso.Append("CENTO");
                        break;
                    case '2':
                        numeroExtenso.Append("DUZENTOS");
                        break;
                    case '3':
                        numeroExtenso.Append("TREZENTOS");
                        break;
                    case '4':
                        numeroExtenso.Append("QUATROCENTOS");
                        break;
                    case '5':
                        numeroExtenso.Append("QUINHENTOS");
                        break;
                    case '6':
                        numeroExtenso.Append("SEISCENTOS");
                        break;
                    case '7':
                        numeroExtenso.Append("SETECENTOS");
                        break;
                    case '8':
                        numeroExtenso.Append("OITOCENTOS");
                        break;
                    case '9':
                        numeroExtenso.Append("NOVECENTOS");
                        break;
                }
            }

            if (valorDigitado[i] != '0' && casa == 2) //Tratando dezena
            {
                if (int.Parse(valorDigitado.Substring(0, i)) != 0)
                {
                    numeroExtenso.Append(" E ");
                }
                switch (valorDigitado[i])
                {
                    case '1':
                        if (valorDigitado[i + 1] == '0')
                        {
                            numeroExtenso.Append("DEZ");
                        }
                        else
                        {
                            switch (valorDigitado[i + 1])
                            {
                                case '1':
                                    numeroExtenso.Append("ONZE");
                                    break;
                                case '2':
                                    numeroExtenso.Append("DOZE");
                                    break;
                                case '3':
                                    numeroExtenso.Append("TREZE");
                                    break;
                                case '4':
                                    numeroExtenso.Append("QUATORZE");
                                    break;
                                case '5':
                                    numeroExtenso.Append("QUINZE");
                                    break;
                                case '6':
                                    numeroExtenso.Append("DEZESSEIS");
                                    break;
                                case '7':
                                    numeroExtenso.Append("DEZESSETE");
                                    break;
                                case '8':
                                    numeroExtenso.Append("DEZOITO");
                                    break;
                                case '9':
                                    numeroExtenso.Append("DEZENOVE");
                                    break;
                            }
                        }
                        break;
                    case '2':
                        numeroExtenso.Append("VINTE");
                        break;
                    case '3':
                        numeroExtenso.Append("TRINTA");
                        break;
                    case '4':
                        numeroExtenso.Append("QUARENTA");
                        break;
                    case '5':
                        numeroExtenso.Append("CINQUENTA");
                        break;
                    case '6':
                        numeroExtenso.Append("SESSENTA");
                        break;
                    case '7':
                        numeroExtenso.Append("SETENTA");
                        break;
                    case '8':
                        numeroExtenso.Append("OITENTA");
                        break;
                    case '9':
                        numeroExtenso.Append("NOVENTA");
                        break;
                }
            }
            if (valorDigitado[i] != '0' && casa == 1 && valorDigitado[i - 1] != '1')
            {

                if (int.Parse(valorDigitado.Substring(0, i)) != 0)
                {
                    numeroExtenso.Append(" E ");
                }
                switch (valorDigitado[i])
                {
                    case '1':
                        numeroExtenso.Append("UM");
                        break;
                    case '2':
                        numeroExtenso.Append("DOIS");
                        break;
                    case '3':
                        numeroExtenso.Append("TRÊS");
                        break;
                    case '4':
                        numeroExtenso.Append("QUATRO");
                        break;
                    case '5':
                        numeroExtenso.Append("CINCO");
                        break;
                    case '6':
                        numeroExtenso.Append("SEIS");
                        break;
                    case '7':
                        numeroExtenso.Append("SETE");
                        break;
                    case '8':
                        numeroExtenso.Append("OITO");
                        break;
                    case '9':
                        numeroExtenso.Append("NOVE");
                        break;
                }
            }
            if (i == 2 && (valorDigitado[i - 2] != '0' || valorDigitado[i - 1] != '0' || valorDigitado[i] != '0'))
            {
                if (int.Parse(valorDigitado[i].ToString()) > 1 || valorDigitado[i - 1] != '0' || valorDigitado[i - 2] != '0')
                {
                    numeroExtenso.Append(" MILHÕES ");
                }
                else
                {
                    numeroExtenso.Append(" MILHÃO ");
                }
            }
            else if (i == 5 && (valorDigitado[i - 2] != '0' || valorDigitado[i - 1] != '0' || valorDigitado[i] != '0'))
            {
                numeroExtenso.Append(" MIL ");
            }
            if (i == 8)
            {
                var teste1 = int.Parse(valorDigitado.Substring(0, 9));
                if (teste1 > 1)
                {
                    numeroExtenso.Append(" REAIS");
                }
                else
                {
                    numeroExtenso.Append(" REAL");
                }
            }
            casa--;
        }
        var casasDecimais = valorDigitado.Substring(valorDigitado.IndexOf(',') + 1, 2);

        if (casasDecimais[0] != '0' || casasDecimais[1] != '0')
        {
            numeroExtenso.Append(" E ");
            if (casasDecimais[0] != '0')
            {
                switch (casasDecimais[0])
                {
                    case '1':
                        if (casasDecimais[1] == '0') { numeroExtenso.Append("DEZ"); break; }
                        break;
                    case '2':
                        numeroExtenso.Append("VINTE");
                        break;
                    case '3':
                        numeroExtenso.Append("TRINTA");
                        break;
                    case '4':
                        numeroExtenso.Append("QUARENTA");
                        break;
                    case '5':
                        numeroExtenso.Append("CINQUENTA");
                        break;
                    case '6':
                        numeroExtenso.Append("SESSENTA");
                        break;
                    case '7':
                        numeroExtenso.Append("SETENTA");
                        break;
                    case '8':
                        numeroExtenso.Append("OITENTA");
                        break;
                    case '9':
                        numeroExtenso.Append("NOVENTA");
                        break;
                }
            }
            if (casasDecimais[0] == '1') //Caso a dezena for 1
            {
                switch (casasDecimais[1])
                {
                    case '1':
                        numeroExtenso.Append("ONZE");
                        break;
                    case '2':
                        numeroExtenso.Append("DOZE");
                        break;
                    case '3':
                        numeroExtenso.Append("TREZE");
                        break;
                    case '4':
                        numeroExtenso.Append("QUATORZE");
                        break;
                    case '5':
                        numeroExtenso.Append("QUINZE");
                        break;
                    case '6':
                        numeroExtenso.Append("DEZESSEIS");
                        break;
                    case '7':
                        numeroExtenso.Append("DEZESSETE");
                        break;
                    case '8':
                        numeroExtenso.Append("DEZOITO");
                        break;
                    case '9':
                        numeroExtenso.Append("DEZENOVE");
                        break;
                }
            }
            if (casasDecimais[1] != '0' && casasDecimais[0] != '1')
            {
                if (casasDecimais[0] != '0') numeroExtenso.Append(" E ");
                switch (casasDecimais[1])
                {
                    case '1':
                        numeroExtenso.Append("UM");
                        break;
                    case '2':
                        numeroExtenso.Append("DOIS");
                        break;
                    case '3':
                        numeroExtenso.Append("TRÊS");
                        break;
                    case '4':
                        numeroExtenso.Append("QUATRO");
                        break;
                    case '5':
                        numeroExtenso.Append("CINCO");
                        break;
                    case '6':
                        numeroExtenso.Append("SEIS");
                        break;
                    case '7':
                        numeroExtenso.Append("SETE");
                        break;
                    case '8':
                        numeroExtenso.Append("OITO");
                        break;
                    case '9':
                        numeroExtenso.Append("NOVE");
                        break;
                }
            }
            numeroExtenso.Append(" CENTAVOS");
        }
        Console.WriteLine(numeroExtenso.ToString());
    }
}


// Escreva um programa que informa o valor por extenso, por exemplo:
// - Valor final da compra: 328,90E VINTE E OITO REAIS E NOVENTA CENTAVOS