using System;
using System.Collections.Generic;

namespace AppPruebaTecnica.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Clave { get; set; }

    public string? Username { get; set; }

    public int? TipoId { get; set; }

    public virtual UsuarioTipo? Tipo { get; set; }
}
