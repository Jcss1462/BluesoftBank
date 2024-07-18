using BluesoftBank.DataRepresentation;
using BluesoftBank.Dto;
using BluesoftBank.Models;
using System.Linq;

namespace BluesoftBank.Services;

public class TransaccionService : ITransaccionService
{
    BlueSoftBankContext context;

    public TransaccionService(BlueSoftBankContext dbcontext)
    {
        context = dbcontext;
    }


    public void ValidarCuenta(int cuentaId)
    {
        // Buscar la cuenta en la base de datos por su Id.
        Cuenta? cuenta = context.Cuentas.Where(item => item.IdCuenta == cuentaId).FirstOrDefault();
        // Si la cuenta no existe, lanzar una excepción.
        if (cuenta == null)
        {
            throw new InvalidOperationException($"No se encontró una cuenta con el Id {cuentaId}.");
        }
    }

    public List<Transaccione> ObtenerEstractoMensual(int cuentaId, int month, int year)
    {
        // valido que la cuenta solicitada exista
        ValidarCuenta(cuentaId);

        List<Transaccione> listaTransacciones = context.Transacciones.Where(item => item.IdCuenta == cuentaId && (item.FechaTransaccion!.Value.Month == month &&
        item.FechaTransaccion!.Value.Year == year)).ToList();

        return listaTransacciones;
    }

    public List<Transaccione> ObtenerMovimientosRecientes(int cuentaId)
    {

        // valido que la cuenta solicitada exista
        ValidarCuenta(cuentaId);

        List<Transaccione> listaTransacciones = context.Transacciones.Where(item => item.IdCuenta == cuentaId && (item.FechaTransaccion >= DateTime.Now.AddDays(-30) &&
        item.FechaTransaccion <= DateTime.Now)).ToList();

        return listaTransacciones;
    }

    public List<NumTransaccionesCliente_DTO> ListaTransaccionesClientesPorMes(int month, int year)
    {
        List<NumTransaccionesCliente_DTO> listaTrasacciones= context.Transacciones
                                                            .Where((item => item.FechaTransaccion!.Value.Month == month 
                                                                            && item.FechaTransaccion!.Value.Year == year)
                                                            ).GroupBy(item=> new { item.IdCuenta, item.IdCuentaNavigation.IdCliente, item.IdCuentaNavigation.IdClienteNavigation!.Nombre, item.IdCuentaNavigation.IdClienteNavigation!.Apellido })
                                                            .Select(grupo=>new NumTransaccionesCliente_DTO
                                                            {
                                                                IdCuenta=grupo.Key.IdCuenta,
                                                                IdCliente= grupo.Key.IdCliente,
                                                                NombreCliente = grupo.Key.Nombre+" "+ grupo.Key.Apellido,
                                                                NumeroTransacciones= grupo.Count()

                                                            }
                                                            ).OrderByDescending(dto => dto.NumeroTransacciones)
                                                            .ToList();

        return listaTrasacciones;
    }

    public List<RetirosForaneos_DTO> ListaClientesRetirosMillonareosForaneos()
    {

        TipoTransaccionEnum transaccionRetiro= TipoTransaccionEnum.Retiro;

        //obtengo trasacciones de retiro que no se hacen en el lugar de origen de la cuenta
        List<RetirosForaneos_DTO> listaRetirosForaneos = context.Transacciones
                                                            .Where(item => (item.IdCiudadTransaccion != item.IdCuentaNavigation.IdCiudadOrigen)
                                                                           && (item.IdTipoTransaccion == (int) transaccionRetiro)
                                                            ).GroupBy(item => new RetirosForaneos_DTO {
                                                                IdCuenta= item.IdCuenta,
                                                                CiudadRetiroCuenta= item.IdCiudadTransaccionNavigation!.Ciudad,
                                                                CiudadOrigenCuenta= item.IdCuentaNavigation.IdCiudadOrigenNavigation!.Ciudad,
                                                                IdCliente= item.IdCuentaNavigation.IdCliente,
                                                                NombreCliente = item.IdCuentaNavigation.IdClienteNavigation!.Nombre+" "+item.IdCuentaNavigation.IdClienteNavigation!.Apellido,
                                                            })
                                                            .Select(grupo => new RetirosForaneos_DTO
                                                            {
                                                                IdCuenta = grupo.Key.IdCuenta,
                                                                IdCliente= grupo.Key.IdCliente,
                                                                NombreCliente = grupo.Key.NombreCliente,
                                                                CiudadRetiroCuenta = grupo.Key.CiudadRetiroCuenta,
                                                                CiudadOrigenCuenta = grupo.Key.CiudadOrigenCuenta,                
                                                                CantidadTotalRetirada = grupo.Sum(item => item.Monto)
                                                            }
                                                            ).OrderByDescending(dto => dto.CantidadTotalRetirada)
                                                            .ToList();

        //filtro la busqueda anterior para solo obtener las transacciones mayores a 1.000.000
        List<RetirosForaneos_DTO> listaRetirosForaneosFiltrada = listaRetirosForaneos.
                                                                Where(item => item.CantidadTotalRetirada > 1000000)
                                                                .ToList();


        return listaRetirosForaneosFiltrada;
    }
}

public interface ITransaccionService
{
    void ValidarCuenta(int cuentaId);

    List<Transaccione> ObtenerMovimientosRecientes(int cuentaId);

    List<Transaccione> ObtenerEstractoMensual(int cuentaId,int month, int year);
    List<NumTransaccionesCliente_DTO> ListaTransaccionesClientesPorMes(int month, int year);

    List<RetirosForaneos_DTO> ListaClientesRetirosMillonareosForaneos();

}
