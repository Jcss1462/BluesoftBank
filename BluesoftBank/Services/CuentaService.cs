using BluesoftBank.Models;

namespace BluesoftBank.Services;

public class CuentaService : ICuentaService
{
    BlueSoftBankContext context;

    public CuentaService(BlueSoftBankContext dbcontext)
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

    public decimal ObtenerSaldoDeCuenta(int cuentaId)
    {


        validarCuenta(cuentaId);
        // Buscar la cuenta en la base de datos por su Id.
        Cuenta? cuenta = context.Cuentas.Where(item=>item.IdCuenta == cuentaId).FirstOrDefault();
        // Devolver el saldo de la cuenta encontrada.
        return cuenta!.Saldo;
    }

    
}

public interface ICuentaService
{
    void validarCuenta(int cuentaId);

    decimal ObtenerSaldoDeCuenta(int cuentaId);
}