using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Repositories;

public interface IAutorRepository
{
    Task<IEnumerable<Autor>> GetUltimoNome(string ultimoNome);
    Task AddAsync(Autor autor);
    Task UpdateAsync(Autor autor);
}