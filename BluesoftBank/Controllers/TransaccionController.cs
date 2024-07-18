using BluesoftBank.Models;
using BluesoftBank.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApisConPuntoNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransaccionController : ControllerBase
{
    ITransaccionService transaccionService;
   
    public TransaccionController(ITransaccionService service)
    {
        transaccionService = service;
    }

  

    [HttpGet("getMovimientosResiente/{id}")]
    public IActionResult getMovimientosResiente(int id)
    {
        List<Transaccione> transaccionesRecientes = transaccionService.ObtenerMovimientosRecientes(id);
        return Ok(transaccionesRecientes);
    }


    [HttpGet("getExtractoMensual/{id}/{month}/{year}")]
    public IActionResult getExtractoMensual(int id, int month, int year)
    {
        List<Transaccione> transaccionesRecientes = transaccionService.ObtenerEstractoMensual(id, month, year);
        return Ok(transaccionesRecientes);
    }


}