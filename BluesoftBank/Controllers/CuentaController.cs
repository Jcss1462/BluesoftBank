using BluesoftBank.Models;
using BluesoftBank.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApisConPuntoNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CuentaController : ControllerBase
{
    ICuentaService cuentaService;
   
    public CuentaController(ICuentaService service)
    {
        cuentaService = service;
    }

    [HttpGet("GetSaldoActualDeCuenta/{id}")]
    public IActionResult GetSaldoActualDeCuenta(int id)
    {
        return Ok($"El saldo de la cuenta {id} es: "+cuentaService.ObtenerSaldoDeCuenta(id));
    }


}