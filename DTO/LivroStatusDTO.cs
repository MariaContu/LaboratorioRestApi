namespace LaboratorioRestApi.DTO;

public class LivroStatusDTO
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    public bool Disponivel { get; set; }
    public DateTime? DataEntregaPrevista { get; set; }

}
