using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.PreciosWebProductos;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    // http://localhost:5235/api/Preciowebproducto
    public class PreciowebproductoController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Crear(RegistrarwebProducto.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<PrecioWebProducto>>> Get(){
            
            return await Mediator.Send(new Consultawebproducto.Listawebproducto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrecioWebProducto>> buscaidweb(Guid id){
           
            return await Mediator.Send(new BuscaIdwebproducto.Ejecuta{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditaWebProducto.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);    
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new EliminarWebProducto.Ejecuta{Id = id});
            
        }
        
    }
}