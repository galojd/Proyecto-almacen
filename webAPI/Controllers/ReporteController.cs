using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Reportes;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    public class ReporteController : Micontrollerbase
    {
        //Aqui esta el reporte de los productos
        //  http://localhost:5235/api/Reporte
        [HttpGet]
        public async Task<ActionResult<List<Reportes>>> Get()
        {
            var resultado = await Mediator.Send(new ReporteProductos.ListaReporte());
            if (resultado == null || !resultado.Any())
            {
                return NotFound(); // o puedes retornar NotFound() si prefieres
            }

        return Ok(resultado);
        }

        //este es el reporte de stock bajo
        // http://localhost:5235/api/Reporte/StockBajo
        [HttpGet("StockBajo")]
        public async Task<ActionResult<List<ReporteStockBajo>>> GetStock()
        {
            return await Mediator.Send(new ReportestockBajos.ListaReportebajo());
        }


        
    }
}