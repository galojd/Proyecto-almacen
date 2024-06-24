using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.DetalleInventarios;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    public class DetalleInventarioController : Micontrollerbase
    {
        //  http://localhost:5235/api/DetalleInventario

        [HttpPost]
        public async Task<ActionResult<string>> Crear(Registradetalleinventario.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<DetalleInventario>>> Get(){
            
            return await Mediator.Send(new Consultadetalleinventario.Listadetalleinventario());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new Eliminardetalleinventario.Ejecuta{Id = id});
            
        }

        // Endpoint para insertar múltiples productos aleatorios
        [HttpPost("seeddetalleinventario")]
        public async Task<ActionResult<Unit>> SeedProductos()
        {
            return await Mediator.Send(new SeedDetalleinventario.InsertadetalleInventario());
        }
        
    }
}