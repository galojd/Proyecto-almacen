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

        //Aqui esta el reporte de los productos
        //  http://localhost:5235/api/Reporte
        [HttpGet("producto-excel")]
        public async Task<ActionResult> GetReporteProductoExcel()
        {
            var resultado = await Mediator.Send(new ReporteProductosExcel.ListaReporte());
            if (resultado == null || !resultado.Any())
            {
                return NotFound(); // o puedes retornar NotFound() si prefieres
            }

            return File(resultado, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte de producto.xlsx");
        }

        //este es el reporte de stock bajo
        // http://localhost:5235/api/Reporte/StockBajo
        [HttpGet("StockBajo")]
        public async Task<ActionResult<List<ReporteStockBajo>>> GetStock()
        {
            return await Mediator.Send(new ReportestockBajos.ListaReportebajo());
        }

        [HttpGet("Stock-bajo-excel")]
        public async Task<ActionResult> GetStockbajo()
        {
            var resultado = await Mediator.Send(new Reportestockbajoexcel.ListaReporte());
            return File(resultado, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte de stock bajo.xlsx");
        }


        
    }
}