using BluesoftBank.Models;

namespace BluesoftBank.Services;

public class CuentaService : ICuentaService
{
    BlueSoftBankContext context;

    public CuentaService(BlueSoftBankContext dbcontext)
    {
        context = dbcontext;
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

    public decimal ObtenerSaldoDeCuenta(int cuentaId)
    {


        validarCuenta(cuentaId);
        // Buscar la cuenta en la base de datos por su Id.
        Cuenta? cuenta = context.Cuentas.Where(item=>item.IdCuenta == cuentaId).FirstOrDefault();
        // Devolver el saldo de la cuenta encontrada.
        return cuenta!.Saldo;
    }

    public void validarCuenta(int cuentaId)
    {
        // Buscar la cuenta en la base de datos por su Id.
        Cuenta? cuenta = context.Cuentas.Where(item => item.IdCuenta == cuentaId).FirstOrDefault();
        // Si la cuenta no existe, lanzar una excepci�n.
        if (cuenta == null)
        {
            throw new InvalidOperationException($"No se encontr� una cuenta con el Id {cuentaId}.");
        }
    }
}

public interface ICuentaService
{
    void validarCuenta(int cuentaId);

    decimal ObtenerSaldoDeCuenta(int cuentaId);

    List<Transaccione> ObtenerMovimientosRecientes(int cuentaId);

    List<Transaccione> ObtenerEstractoMensual(int cuentaId,int month, int year);

}