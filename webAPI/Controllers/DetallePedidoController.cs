using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.DetallePedidos;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    // http://localhost:5235/api/DetallePedido
    public class DetallePedidoController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(RegistrarDetallepedido.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<DetallePedido>>> Get(){
            
            return await Mediator.Send(new ConsultaDetallepedido.ListaDetallepedido());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> buscaidcomprapago(Guid id){
           
            return await Mediator.Send(new BuscaIdDetallepedido.Ejecuta{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarDetallepedido.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);    
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new EliminarDetallepedido.Ejecuta{Id = id});
            
        }

        // Endpoint para insertar múltiples productos aleatorios
        [HttpPost("seeddetallepedido")]
        public async Task<ActionResult<Unit>> SeedProductos()
        {
            return await Mediator.Send(new SeedDetallePedido.Insertadetallepedido());
        }
        
    }
}