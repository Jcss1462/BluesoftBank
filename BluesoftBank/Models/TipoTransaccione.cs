using System;
using System.Collections.Generic;

namespace BluesoftBank.Models;

public partial class TipoTransaccione
{
    public int IdTipoTransaccion { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
