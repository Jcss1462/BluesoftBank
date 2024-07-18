using BluesoftBank.Dto;
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

  

    [HttpGet("GetMovimientosResiente/{id}")]
    public IActionResult GetMovimientosResiente(int id)
    {
        List<Transaccione> transaccionesRecientes = transaccionService.ObtenerMovimientosRecientes(id);
        return Ok(transaccionesRecientes);
    }


    [HttpGet("GetExtractoMensual/{id}/{month}/{year}")]
    public IActionResult GetExtractoMensual(int id, int month, int year)
    {
        List<Transaccione> transaccionesRecientes = transaccionService.ObtenerEstractoMensual(id, month, year);
        return Ok(transaccionesRecientes);
    }



    [HttpGet("GetTransaccionesClientesPorMes/{month}/{year}")]
    public IActionResult GetTransaccionesClientesPorMes(int month, int year)
    {
        List<NumTransaccionesCliente_DTO> transaccionesClientesPorMes = transaccionService.ListaTransaccionesClientesPorMes(month, year);
        return Ok(transaccionesClientesPorMes);
    }


}