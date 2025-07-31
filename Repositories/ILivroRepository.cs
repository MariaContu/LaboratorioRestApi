using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Repositories;

public interface ILivroRepository
{
    Task AddAsync(Livro livro);
    Task<IEnumerable<Livro>> GetAllAsync();
    Task<IEnumerable<Livro>> GetLivrosByAutorIdAsync(long autoresId);
}