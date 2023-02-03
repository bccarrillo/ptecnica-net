using System;
using System.Collections.Generic;

namespace AppPruebaTecnica.Models;

public partial class Cliente
{
    public string? Nombre { get; set; }

    public string? Codigo { get; set; }

    public int? Edad { get; set; }

    public int? Telefono { get; set; }

    public string? Accion { get; set; }
}
