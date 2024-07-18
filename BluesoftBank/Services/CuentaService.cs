using BluesoftBank.Models;

namespace BluesoftBank.Services;

public class CuentaService : ICuentaService
{
    BlueSoftBankContext context;

    public CuentaService(BlueSoftBankContext dbcontext)
    {
        context = dbcontext;
    }
    
    public decimal ObtenerSaldoDeCuenta(int cuentaId)
    {
        // Buscar la cuenta en la base de datos por su Id.
        Cuenta? cuenta = context.Cuentas.Where(item=>item.IdCuenta == cuentaId).FirstOrDefault();

        // Si la cuenta no existe, lanzar una excepci�n.
        if (cuenta == null)
        {
            throw new InvalidOperationException($"No se encontr� una cuenta con el Id {cuentaId}.");
        }

        // Devolver el saldo de la cuenta encontrada.
        return cuenta.Saldo;
    }
}

public interface ICuentaService
{

    decimal ObtenerSaldoDeCuenta(int cuentaId);

}