using BluesoftBank.Models;

namespace BluesoftBank.Services;

public class CuentaService : ICuentaService
{
    BlueSoftBankContext context;

    public CuentaService(BlueSoftBankContext dbcontext)
    {
        context = dbcontext;
    }

    public List<Transaccione> ObtenerMovimientosRecientes(int cuentaId)
    {

        // valido que la cuenta solicitada exista
        Cuenta? cuenta = context.Cuentas.Where(item => item.IdCuenta == cuentaId).FirstOrDefault();
        // Si la cuenta no existe, lanzar una excepción.
        if (cuenta == null)
        {
            throw new InvalidOperationException($"No se encontró una cuenta con el Id {cuentaId}.");
        }

        List<Transaccione> listaTransacciones = context.Transacciones.Where(item => item.IdCuenta == cuentaId && (item.FechaTransaccion >= DateTime.Now.AddDays(-30) &&
        item.FechaTransaccion <= DateTime.Now)).ToList();

        return listaTransacciones;
    }

    public decimal ObtenerSaldoDeCuenta(int cuentaId)
    {
        // Buscar la cuenta en la base de datos por su Id.
        Cuenta? cuenta = context.Cuentas.Where(item=>item.IdCuenta == cuentaId).FirstOrDefault();

        // Si la cuenta no existe, lanzar una excepción.
        if (cuenta == null)
        {
            throw new InvalidOperationException($"No se encontró una cuenta con el Id {cuentaId}.");
        }

        // Devolver el saldo de la cuenta encontrada.
        return cuenta.Saldo;
    }
}

public interface ICuentaService
{

    decimal ObtenerSaldoDeCuenta(int cuentaId);

    List<Transaccione> ObtenerMovimientosRecientes(int cuentaId);

}