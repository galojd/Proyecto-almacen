using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.InventariosProductos;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    // http://localhost:5235/api/InventarioProducto
    public class InventarioProductoController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(RegistrarInventarioProducto.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<InventarioProducto>>> Get(){
            
            return await Mediator.Send(new Consultainventarioproducto.ListainventarioProducto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventarioProducto>> buscaidcomprapago(Guid id){
           
            return await Mediator.Send(new BuscaIdinventarioproducto.Ejecuta{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarInventarioproducto.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);    
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new EliminarInventarioProducto.Ejecuta{Id = id});
            
        }
    }
}