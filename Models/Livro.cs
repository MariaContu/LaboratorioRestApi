namespace LaboratorioRestApi.Models;

public class Livro
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    
    public List<Autor> Autores { get; set; } = null!;
    public List<Emprestimo> Emprestimos { get; set; } = null!;
}