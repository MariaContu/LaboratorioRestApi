using LaboratorioRestApi.DTO;
using LaboratorioRestApi.Repositories;

namespace LaboratorioRestApi.Services;

public class LaboratorioRestApiServices
{
    public readonly IAutorRepository _autorRepository;
    public readonly IEmprestimoRepository _emprestimoRepository;
    public readonly ILivroRepository _livroRepository;

    public LaboratorioRestApiServices(
        IAutorRepository autorRepository,
        IEmprestimoRepository emprestimoRepository,
        ILivroRepository livroRepository)
    {   
        _autorRepository = autorRepository;
        _emprestimoRepository = emprestimoRepository;
        _livroRepository = livroRepository;
    }
    
    //consultar livros
    public async Task<IEnumerable<LivroStatusDTO>> ConsultarLivrosPorAutor(long autorId)
    {
        var livros = await _livroRepository.GetLivrosByAutorIdAsync(autorId);
        var resultado = new List<LivroStatusDTO>();

        foreach (var l in livros)
        {
            var emprestimo = await _emprestimoRepository.GetEmprestimoAbertoPorLivro(l.Id);
            resultado.Add(new LivroStatusDTO
            {
                Id = l.Id,
                Titulo = l.Titulo,
                Disponivel = emprestimo == null,
                DataEntregaPrevista = emprestimo?.DataRetirada.AddDays(7)
            });
        }
        return resultado;
    }
    
    //emprestar livro
    
    //devolver livro
    
}