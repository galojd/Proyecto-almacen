using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Productos;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    public class ProductoController : Micontrollerbase
    {
        // http://localhost:5235/api/Producto
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(RegistrarProducto.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get(){
            
            return await Mediator.Send(new ConsultaProducto.ListaProducto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> buscaidcomprapago(Guid id){
           
            return await Mediator.Send(new BuscaIdProducto.Ejecuta{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarProducto.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);    
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new EliminarProducto.Ejecuta{Id = id});
            
        }
        
    }
}