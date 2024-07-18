using System;
using System.Collections.Generic;

namespace BluesoftBank.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int IdTipoCliente { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? TipoDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? RazonSocial { get; set; }

    public string? NombreComercial { get; set; }

    public string? Ruc { get; set; }

    public string? ContactoPrincipal { get; set; }

    public string? TelefonoContacto { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();

    public virtual TipoCliente IdTipoClienteNavigation { get; set; } = null!;
}
