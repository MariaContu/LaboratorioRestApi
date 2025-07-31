using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Repositories;

public interface IEmprestimoRepository
{
    Task AddAsync(Emprestimo emprestimo);
    Task UpdateAsync(Emprestimo emprestimo);
    Task<Emprestimo?> GetEmprestimoAbertoPorLivro(long livroId);
}