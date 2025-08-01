using Microsoft.AspNetCore.Mvc;
using LaboratorioRestApi.Models;
using LaboratorioRestApi.Repositories;

namespace LaboratorioRestApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class LivroController : ControllerBase
{
    public readonly ILivroRepository _livroRepository;

    public LivroController(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }
    
    //GET /api/livro/{id}

    [HttpGet("id")]
    public async Task<IActionResult> GetLivroPorId(long id)
    {
        try
        {
            var livros = await _livroRepository.GetAllAsync();
            var livro = livros.FirstOrDefault(l => l.Id == id);

            if (livro == null)
                return NotFound(); //404

            return Ok(livro); //200
        }

        catch (Exception)
        {
        return StatusCode(500, "Internal server error");
        }
    }
}