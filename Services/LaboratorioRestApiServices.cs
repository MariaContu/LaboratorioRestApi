using LaboratorioRestApi.DTO;
using LaboratorioRestApi.Models;
using LaboratorioRestApi.Repositories;

namespace LaboratorioRestApi.Services;

public class LaboratorioRestApiServices
{
    public readonly IAutorRepository _autorRepository;
    public readonly IEmprestimoRepository _emprestimoRepository;
    public readonly ILivroRepository _livroRepository;

    private const decimal MultaPorDia = 3.50m; //multa por dia de atraso
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
    public async Task<bool> EmprestarLivro(long livroId)
    {
        var emprestimoExistente = await _emprestimoRepository.GetEmprestimoAbertoPorLivro(livroId);
        if (emprestimoExistente != null)
            return false; //livro indisponivel

        var novoEmprestimo = new Emprestimo
        {
            LivroId = livroId,
            DataRetirada = DateTime.Now,
            DataEntregaPrevista = DateTime.Now.AddDays(7),
            Entregue = false
            
        };
        
        await _emprestimoRepository.AddAsync(novoEmprestimo);
        return true;
    }
    
    //devolver livro
    public async Task<decimal?> DevolverLivro(long livroId)
    {
        var emprestimo = await _emprestimoRepository.GetEmprestimoAbertoPorLivro(livroId);
        
        if (emprestimo == null)
            return null; //nenhum emprestimo em aberto
        
        emprestimo.DataDevolucao = DateTime.Now;
        await _emprestimoRepository.UpdateAsync(emprestimo);

        if (emprestimo.DataDevolucao > emprestimo.DataEntregaPrevista)
        {
            var diasAtraso = (emprestimo.DataDevolucao.Value - emprestimo.DataEntregaPrevista.Value).Days;
            return diasAtraso * MultaPorDia;
        }
        return 0;
    }
}