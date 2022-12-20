using Balta.ContentContext;
namespace Balta;

class Program
{
    public static void Main()
    {
        var articles = new List<Article>();
        articles.Add(new Article("Dotnet é legal!", "Site do dotnet"));
        articles.Add(new Article("CSharp é muito bom", "Site do CSHARP"));
        articles.Add(new Article(".net é legal!", "Site do Dot"));

        // foreach (Article article in articles)
        // {
        //     Console.WriteLine(article.Id);
        //     Console.WriteLine(article.Title);
        //     Console.WriteLine(article.Url);
        //     Console.WriteLine("----------------------");
        // }
        var courses = new List<Course>();
        var course = new Course("Fundamentos OOP", "fundamentos-oop");
        var courseCSharp = new Course("Fundamentos C#", "fundamentos-c#");
        var courseAspNet = new Course("Fundamentos Asp.net", "fundamentos-asp.net");
        courses.Add(courseAspNet);
        courses.Add(courseCSharp);
        courses.Add(course); //Adicionando cursos na lista de cursos
        var carrers = new List<Carrer>();
        var carrerDotnet = new Carrer("Especialista em Dotnet", "Especialista-dotnet");
        var carrerItem = new CarrerItem(1, "Comece por aqui", "", course);
        carrerDotnet.Items.Add(carrerItem); //Adicionando um carrerItem na carreira criada
        carrerDotnet.Items.Add(new CarrerItem(3, "Aprendendo fundamental", "", courseCSharp));
        carrerDotnet.Items.Add(new CarrerItem(2, "Aprendendo POO", "", courseAspNet));
        carrers.Add(carrerDotnet); //Adicionando carreira criada na lista de carreiras

        foreach (var carrer in carrers)
        {
            Console.WriteLine(carrer.Title);
            foreach (var item in carrer.Items.OrderBy(x => x.Order)) //Ordenando por Order
            {
                Console.WriteLine($"{item.Order}-{item.Title}");
                Console.WriteLine(item.Course?.Title);
                Console.WriteLine(item.Course?.Level);
                foreach (var notification in item.Notifications)
                {
                    Console.WriteLine($"{notification.MyProperty} - {notification.Message}");
                }
            }
        }
    }
}