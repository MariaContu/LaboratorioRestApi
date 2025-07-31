using LaboratorioRestApi.Models;
using Microsoft.EntityFrameworkCore;
namespace LaboratorioRestApi.Data;

public class LaboratorioRestApiDbContext : DbContext
{
    public LaboratorioRestApiDbContext(DbContextOptions<LaboratorioRestApiDbContext> options) : base(options){}
    
    DbSet<Autor> Autores { get; set; }
    
    DbSet<Emprestimo> Emprestimos { get; set; }
    
    DbSet<Livro> Livros { get; set; }
    
    
}