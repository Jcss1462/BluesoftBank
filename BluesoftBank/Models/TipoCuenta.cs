using System;
using System.Collections.Generic;

namespace BluesoftBank.Models;

public partial class TipoCuenta
{
    public int IdTipoCuenta { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();
}
