using System;
using System.Collections.Generic;

namespace BluesoftBank.Models;

public partial class Ciudade
{
    public int IdCiudad { get; set; }

    public string? Ciudad { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
