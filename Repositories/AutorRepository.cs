using LaboratorioRestApi.Data;
using LaboratorioRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repositories;

public class AutorRepository : IAutorRepository
{
    public readonly LaboratorioRestApiDbContext _context;

    public AutorRepository(LaboratorioRestApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Autor>> GetUltimoNome(string ultimoNome)
    {
        return await _context.Autores.Where(a => a.UltimoNome == ultimoNome).ToListAsync();
    }

    public async Task AddAsync(Autor autor)
    {
        _context.Autores.Add(autor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Autor autor)
    {
        _context.Autores.Update(autor);
        await _context.SaveChangesAsync();
    }
}