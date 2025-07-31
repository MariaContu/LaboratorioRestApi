using LaboratorioRestApi.Models;
using Microsoft.EntityFrameworkCore;
namespace LaboratorioRestApi.Data;

public class LaboratorioRestApiDbContext : DbContext
{
    public LaboratorioRestApiDbContext(DbContextOptions<LaboratorioRestApiDbContext> options) : base(options){}
    
  public DbSet<Autor> Autores { get; set; }
  
  public DbSet<Emprestimo> Emprestimos { get; set; }
    
  public DbSet<Livro> Livros { get; set; }
    
    
}