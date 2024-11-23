using System.Globalization;

namespace livrariaDoEdu.Communication.Response;

public class ResponseLivroJson
{
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Genero { get; set;} = string.Empty;
    public int QtdEstoque {  get; set; }
    public decimal PrecoLivro { get; set; }
}
