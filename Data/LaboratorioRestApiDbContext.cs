using LaboratorioRestApi.Models;
using Microsoft.EntityFrameworkCore;
namespace LaboratorioRestApi.Data;

public class LaboratorioRestApiDbContext : DbContext
{
    public LaboratorioRestApiDbContext(DbContextOptions<LaboratorioRestApiDbContext> options) : base(options){}
    
  public DbSet<Autor> Autores { get; set; }
  
  public DbSet<Emprestimo> Emprestimos { get; set; }
    
  public DbSet<Livro> Livros { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
      //autor e livro muitos para muitos 
      modelBuilder.Entity<Autor>()
          .HasMany(a => a.Livros)
          .WithMany(l => l.Autores)
          .UsingEntity<Dictionary<string, object>>(
              "AuthorBook", 
              ab => ab.HasOne<Livro>().WithMany().HasForeignKey("LivroId"),
              ab => ab.HasOne<Autor>().WithMany().HasForeignKey("AutorId")
          );

      //livro e empréstimo um para muitos
      modelBuilder.Entity<Livro>()
          .HasMany(l => l.Emprestimos)
          .WithOne(e => e.Livro)
          .HasForeignKey(e => e.LivroId);
  }


}