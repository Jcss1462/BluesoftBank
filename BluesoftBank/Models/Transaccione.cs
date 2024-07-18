using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BluesoftBank.Models;

public partial class Transaccione
{
    public int Id { get; set; }

    public int IdCuenta { get; set; }

    public int IdTipoTransaccion { get; set; }

    public decimal Monto { get; set; }

    public DateTime? FechaTransaccion { get; set; }

    public int? IdCiudadTransaccion { get; set; }

    public virtual Ciudade? IdCiudadTransaccionNavigation { get; set; }

    [JsonIgnore]
    public virtual Cuenta IdCuentaNavigation { get; set; } = null!;

    public virtual TipoTransaccione IdTipoTransaccionNavigation { get; set; } = null!;
}
