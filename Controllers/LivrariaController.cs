using livrariaDoEdu.Communication.Request;
using livrariaDoEdu.Communication.Response;
using livrariaDoEdu.Entidades;
using livrariaDoEdu.Infraestructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace livrariaDoEdu.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LivrariaController : ControllerBase
{
    private readonly LivrariaDbContext _livrariaDbContext;
    public LivrariaController (LivrariaDbContext livrariaDbContext)
    {
        _livrariaDbContext = livrariaDbContext;
    }

    [HttpGet, Route("/BuscarLivroPorId/{id}")]
    [ProducesResponseType(typeof(ResponseLivroJson),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult BuscaLivroPorId([FromRoute] int id)
    {
        var livro = _livrariaDbContext.Livros.Find(id);

        return Ok(livro);
    }

    [HttpGet, Route("/BuscarLivrosCadastrados")]
    [ProducesResponseType(typeof(ResponseLivroJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult BuscarLivrosCadastrados()
    {
        try
        {
           var livros =  _livrariaDbContext.Livros.ToList();
           return Ok(livros);

        } catch(Exception e)
        {
            throw new Exception(e.Message);
        }  
    }

    [HttpPost, Route("/CadastrarLivro")]
    [ProducesResponseType(typeof(Livro), StatusCodes.Status201Created)]
    public IActionResult CadastrarLivro([FromBody] RequestLivroJson requestLivro)
    {
        var cadLivro = new Livro
        {
            Id = requestLivro.Id,
            Titulo = requestLivro.Titulo,
            Autor = requestLivro.Autor,
            Genero = requestLivro.Genero,
            QuantidadeEstoque = requestLivro.QuantidadeEstoque,
            PrecoProduto = requestLivro.Preco,
        };
        try
        {
            _livrariaDbContext.Add(cadLivro);
            _livrariaDbContext.SaveChanges();
        } catch(Exception e)
        {
            throw new Exception(e.Message);
        }
       return Created(string.Empty, cadLivro);
    }

    [HttpPut, Route("/AtualizarLivro/{id}")]
    [ProducesResponseType(typeof(Livro), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AtualizarLivro([FromRoute] int id, [FromBody] Livro livroRequest)
    {
        var livroemBase = _livrariaDbContext.Livros.Find(id);

        if(livroemBase is null)
        {
            return BadRequest("Dados do livro inválidos");
        }

        livroemBase.Titulo = livroRequest.Titulo;
        livroemBase.Autor = livroRequest.Autor;
        livroemBase.Genero = livroRequest.Genero;
        livroemBase.QuantidadeEstoque = livroRequest.QuantidadeEstoque;
        livroemBase.PrecoProduto = livroRequest.PrecoProduto;

        try
        {
            _livrariaDbContext.SaveChanges();
        } catch(Exception e)
        {
            throw new Exception(e.Message);
        }

        return NoContent();   
    }

    [HttpDelete, Route("/DeletarLivro/{id}")]
    [ProducesResponseType(typeof(Livro), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeletarLivro([FromRoute]int id)
    {
        var livro = _livrariaDbContext.Livros.Find(id);
        if(livro is null)
        {
            return BadRequest("A requisição não pode ser completada, tente novamente mais tarde!");
        }

        try
        {
            _livrariaDbContext.Remove(livro);
        } catch(Exception e)
        {
            throw new Exception(e.Message);
        }
        return NoContent();
    }
}
