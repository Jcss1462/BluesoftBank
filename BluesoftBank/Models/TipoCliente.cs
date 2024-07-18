using System;
using System.Collections.Generic;

namespace BluesoftBank.Models;

public partial class TipoCliente
{
    public int IdTipoCliente { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
