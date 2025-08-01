namespace LaboratorioRestApi.Models;

public class Emprestimo
{
    public long Id { get; set; }
    public DateTime DataRetirada { get; set; }
    public DateTime? DataDevolucao { get; set; }
    public bool Entregue { get; set; }
    
    public long LivroId { get; set; }
    public Livro Livro { get; set; }
}