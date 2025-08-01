using LaboratorioRestApi.Data;
using LaboratorioRestApi.Models;
using Microsoft.EntityFrameworkCore;
using LaboratorioRestApi.Repositories;

namespace LaboratorioRestApi.Repositories;

public class LivroRepository : ILivroRepository
{
    public readonly LaboratorioRestApiDbContext _context;

    public LivroRepository(LaboratorioRestApiDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Livro livro)
    {
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Livro>> GetAllAsync()
    {
        return await _context.Livros.Include(l => l.Autores).ToListAsync();
    }

    public async Task<IEnumerable<Livro>> GetLivrosByAutorIdAsync(long autorId)
    {
        var autorE = _context.Autores.Where(a => a.Id == autorId).FirstOrDefaultAsync();
        return await _context.Livros.Where(l => l.Autores.Any(a => a.Equals(autorE))).ToListAsync();
    }
    
}