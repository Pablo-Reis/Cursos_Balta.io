using System.Globalization;

namespace Datas
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            //DateTime data = new(); Exibe 01/01/0001
            DateTime data = DateTime.Now; //Exibe a data atual
            Console.WriteLine(data.Year); //Exibe o ano
            Console.WriteLine(data.Month);//Exibe o mês
            Console.WriteLine(data.Day);// Exibe o dia
            Console.WriteLine(data.DayOfWeek); //Exibe o dia da semana
            Console.WriteLine(data.Second); //Exibe os segundos
            Console.WriteLine(String.Format("{0:yy/MM/dd}", data)); //Formatando datas
            Console.WriteLine(data.AddDays(1));
            // if (data < DateTime.Now)
            // {
            //     Console.Write("É diferente!");
            // }
            CultureInfo pt = new CultureInfo("pt-PT");
            CultureInfo br = new CultureInfo("pt-BR");
            CultureInfo en = new CultureInfo("en-US");
            CultureInfo de = new CultureInfo("de-DE");
            Console.WriteLine(DateTime.Now.ToString("D", br));
            CultureInfo atual = CultureInfo.CurrentCulture; //Pega a cultura atual
            Console.WriteLine(atual.ToString()); //Exibe a cultura atual

            DateTime utc = DateTime.UtcNow; //Creio que pega o horário de Greenwich (0)
            Console.WriteLine(utc);
            Console.WriteLine(utc.ToLocalTime()); //Utiliza uma cultureInfo
            TimeZoneInfo timezone = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
            Console.WriteLine(timezone);
            DateTime timeZoneAustralia = TimeZoneInfo.ConvertTimeFromUtc(utc, timezone);
            Console.WriteLine(timeZoneAustralia);
            // var timezones = TimeZoneInfo.GetSystemTimeZones();

            // foreach (var Timezone in timezones)
            // {
            //     Console.WriteLine(Timezone.Id);
            //     Console.WriteLine(Timezone);
            //     Console.WriteLine("--------------");
            // }

            Console.Clear();
            //TimeSpan timeSpan = new TimeSpan(); //Traz um timespan zerado
            TimeSpan timeSpan = new(10, 20, 30, 40, 100);
            Console.WriteLine(timeSpan);
            Console.WriteLine(timeSpan.Days);
            Console.WriteLine(timeSpan.Hours);
            Console.WriteLine(timeSpan.Minutes);
            Console.WriteLine(timeSpan.Seconds);
            Console.WriteLine(timeSpan.Milliseconds);
            Console.WriteLine(timeSpan.Add(new TimeSpan(0, 10, 0)));
            Console.WriteLine(timeSpan);

        }
    }
}
