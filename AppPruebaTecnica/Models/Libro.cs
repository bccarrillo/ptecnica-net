using System;
using System.Collections.Generic;

namespace AppPruebaTecnica.Models;

public partial class Libro
{
    public int Id { get; set; }

    public int? EditorialesId { get; set; }

    public string? Titulo { get; set; }

    public string? Sinopsis { get; set; }

    public string? NPaginas { get; set; }
}
