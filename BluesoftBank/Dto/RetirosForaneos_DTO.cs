namespace BluesoftBank.Dto;

public partial class RetirosForaneos_DTO
{
    public int? IdCliente { get; set; }
    public string? NombreCliente { get; set; }
    public int IdCuenta { get; set; }
    public string? CiudadOrigenCuenta { get; set; }

    public string? CiudadRetiroCuenta { get; set; }

    public decimal? CantidadTotalRetirada { get; set; }

}
