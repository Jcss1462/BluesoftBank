using System;
using System.Collections.Generic;

namespace BluesoftBank.Models;

public partial class Cuenta
{
    public int IdCuenta { get; set; }

    public int? IdCliente { get; set; }

    public int IdTipoCuenta { get; set; }

    public decimal Saldo { get; set; }

    public string? CiudadOrigen { get; set; }

    public DateOnly? FechaApertura { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual TipoCuenta IdTipoCuentaNavigation { get; set; } = null!;

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
