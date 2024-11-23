using System.Numerics;

namespace livrariaDoEdu.Communication.Request;

public class RequestLivroJson
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public int QuantidadeEstoque { get; set; }
    public decimal Preco { get; set; }
}
