using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Screens.UserRoleScreen;

public static class CreatePostTagScreen
{
    public static void Load()
    {
        Console.Clear();
        try
        {
            System.Console.Write("ID do post que deseja vincular: ");
            var postId = int.Parse(Console.ReadLine());
            var post = new Repository<Post>(Database.Connection).Get(postId);
            if (post is null)
            {
                System.Console.WriteLine("Post não encontrado!");
                Console.ReadKey();
                Load();
            }
            System.Console.Write("ID da tag que deseja adicionar ao post: ");
            var tagId = int.Parse(Console.ReadLine());
            var tag = new Repository<Tag>(Database.Connection).Get(tagId);
            if (tag is null)
            {
                System.Console.WriteLine("Tag não encontrada!");
                Console.ReadKey();
                Load();
            }
            Link(post.Id, tag.Id);

        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Houve um erro ao vincular post à tag: {e.Message}");
            Console.ReadKey();
            Program.Load();
        }
    }

    private static void Link(int idPost, int idTag)
    {
        var query = "INSERT INTO [PostTag] ([PostId], [TagId]) VALUES (@PostId, @TagId)";
        var rows = Database.Connection.Execute(query, new
        {
            PostId = idPost,
            TagId = idTag
        });
        if (rows > 0) System.Console.WriteLine("Vínculo feito com sucesso!");
        else
        {
            System.Console.WriteLine("Não foi possível incluir vínculo");
        }
        Console.ReadKey();
        Program.Load();
    }
}