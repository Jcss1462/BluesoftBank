using BluesoftBank.Models;

namespace BluesoftBank.Services;

public class TransaccionService : ITransaccionService
{
    BlueSoftBankContext context;

    public TransaccionService(BlueSoftBankContext dbcontext)
    {
        context = dbcontext;
    }


    public void validarCuenta(int cuentaId)
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
        validarCuenta(cuentaId);

        List<Transaccione> listaTransacciones = context.Transacciones.Where(item => item.IdCuenta == cuentaId && (item.FechaTransaccion!.Value.Month == month &&
        item.FechaTransaccion!.Value.Year == year)).ToList();

        return listaTransacciones;
    }

    public List<Transaccione> ObtenerMovimientosRecientes(int cuentaId)
    {

        // valido que la cuenta solicitada exista
        validarCuenta(cuentaId);

        List<Transaccione> listaTransacciones = context.Transacciones.Where(item => item.IdCuenta == cuentaId && (item.FechaTransaccion >= DateTime.Now.AddDays(-30) &&
        item.FechaTransaccion <= DateTime.Now)).ToList();

        return listaTransacciones;
    }

}

public interface ITransaccionService
{
    void validarCuenta(int cuentaId);

    List<Transaccione> ObtenerMovimientosRecientes(int cuentaId);

    List<Transaccione> ObtenerEstractoMensual(int cuentaId,int month, int year);

}