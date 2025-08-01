﻿namespace LaboratorioRestApi.Models;

public class Autor
{
    public long Id { get; set; }
    public string PrimeiroNome { get; set; }
    public string UltimoNome { get; set; }

    public ICollection<Livro> Livros { get; set; } = null!;
}