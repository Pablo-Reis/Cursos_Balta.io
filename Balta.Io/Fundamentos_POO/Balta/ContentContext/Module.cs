using Balta.SharedContext;
namespace Balta.ContentContext;
public class Module : Base
{
    public Module()
    {
        Lectures = new List<Lecture>();
    }
    public IList<Lecture> Lectures { get; set; }
    public int Order { get; set; }
    public string Title { get; set; }
}