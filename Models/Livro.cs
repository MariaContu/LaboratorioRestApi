namespace LaboratorioRestApi.Models;

public class Livro
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    
    public ICollection<Autor> Autores { get; set; }
    public ICollection<Emprestimo> Emprestimos { get; set; }
}