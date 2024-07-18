namespace BluesoftBank.Dto;

public partial class NumTransaccionesCliente_DTO
{
    public int IdCuenta { get; set; }
    public int? IdCliente { get; set; }
    public string? NombreCliente { get; set; }

    public int? NumeroTransacciones { get; set; }


}
