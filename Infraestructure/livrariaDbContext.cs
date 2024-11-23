using livrariaDoEdu.Entidades;
using Microsoft.EntityFrameworkCore;

namespace livrariaDoEdu.Infraestructure;

public class LivrariaDbContext : DbContext
{
    public LivrariaDbContext(DbContextOptions<LivrariaDbContext>options) : base(options) 
    { }
    public DbSet<Livro> Livros { get; set; }
}
