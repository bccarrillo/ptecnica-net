using System;
using System.Collections.Generic;

namespace AppPruebaTecnica.Models;

public partial class UsuarioTipo
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
