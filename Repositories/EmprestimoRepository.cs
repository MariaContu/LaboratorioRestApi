using LaboratorioRestApi.Data;
using LaboratorioRestApi.Models;
using LaboratorioRestApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repositories;

public class EmprestimoRepository : IEmprestimoRepository
{
    public readonly LaboratorioRestApiDbContext _context;

    public EmprestimoRepository(LaboratorioRestApiDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Emprestimo emprestimo)
    {
        _context.Emprestimos.Add(emprestimo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Emprestimo emprestimo)
    {
        _context.Emprestimos.Update(emprestimo);
        await _context.SaveChangesAsync();
    }

    public async Task<Emprestimo?> GetEmprestimoAbertoPorLivro(long livroId)
    {
        return await _context.Emprestimos.Where(e => e.LivroId == livroId && e.DataDevolucao != null).FirstOrDefaultAsync();
    }
}