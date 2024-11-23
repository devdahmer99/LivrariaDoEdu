using System.ComponentModel.DataAnnotations;

namespace livrariaDoEdu.Entidades;

public class Livro
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(250)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Autor { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    public string Genero { get; set; } = string.Empty;

    [Required]
    public int QuantidadeEstoque { get; set; } = 0;

    [Required]
    public decimal PrecoProduto { get; set; }
}
