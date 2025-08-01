namespace LaboratorioRestApi.DTO;

public class EmprestimoDTO
{
    public long Id { get; set; }
    public DateTime DataRetirada { get; set; }
    public DateTime? DataDevolucao { get; set; }
    public bool Entregue { get; set; }
    
    
    public long LivroId { get; set; }
    public string? TituloLivro { get; set; } // opcional exibir o nome do livro
}