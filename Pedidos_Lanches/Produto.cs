namespace Pedidos_Lanches;

class Produto
{
    public int Id { get; private set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public Produto()
    {
    }
    public Produto(string nome, decimal valor, int Quantidade = 0) : this()
    {
        this.Quantidade = Quantidade;
        this.Nome = nome;
        this.Valor = valor;
    }

    public static List<Produto> GetAll() => Program.Produtos;
    public static Produto Get(int id)
    {
        var prod = Program.Produtos.FirstOrDefault(p => p.Id == id);
        if (prod is not null) return prod;
        else return null;
    }
    public static void Add(Produto produto)
    {
        produto.Id = Program.Produtos.Count + 1;
        Program.Produtos.Add(produto);
    }
    public static bool Remove(int id)
    {
        var index = Program.Produtos.FindIndex(p => p.Id == id);
        if (index == -1) return false;
        else Program.Produtos.RemoveAt(index);
        return true;
    }
    public static void Update(Produto produto)
    {
        var prod = Program.Produtos.FindIndex(p => p.Id == produto.Id);
        if (prod == -1) Program.Produtos[prod] = produto;
        else return;
    }
}