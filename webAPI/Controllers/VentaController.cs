using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Clientes;
using Aplicacion.Ventas;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// http://localhost:5235/api/Venta
namespace webAPI.Controllers
{
    public class VentaController: Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Crear(Registrarventa.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpPost("registrarventa")]
        public async Task<ActionResult<string>> Crearventa(RegistrarVentaPedido.Ejecuta data){
            return await Mediator.Send(data);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<VentaDto>>> Get(){
            
            return await Mediator.Send(new Consultaventa.ListaVentas());
        }

        [HttpGet("ventafiltrada")]
        public async Task<ActionResult<List<VentaFiltrada>>> Getventafiltrada(){
            
            return await Mediator.Send(new FiltrarVenta.ListaVentas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> buscaidventa(Guid id){
           
            return await Mediator.Send(new BuscarIdventas.Ejecuta{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarVenta.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);    
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new Eliminarventa.Ejecuta{Id = id});
            
        }

        // Endpoint para insertar múltiples productos aleatorios
        [HttpPost("seedventa")]
        public async Task<ActionResult<Unit>> SeedProductos()
        {
            return await Mediator.Send(new SeedVenta.InsertaVenta());
        }
    }
}