using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Devoluciones;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    // http://localhost:5235/api/Devolucion
    public class DevolucionController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Crear(RegistrarDevolcion.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpPost("RegistrarDevolucion")]
        public async Task<ActionResult<string>> Creardevolucion(Registradevolucionproducto.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<devolucionDTO>>> Get(){
            
            return await Mediator.Send(new ConsultaDevolucion.Listadevolucion());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Devolucion>> buscaidcomprapago(Guid id){
           
            return await Mediator.Send(new BuscaIdDevolucion.Ejecuta{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditaDevolucion.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);    
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new EliminarDevolucion.Ejecuta{Id = id});
            
        }

        // Endpoint para insertar múltiples productos aleatorios
        [HttpPost("seeddevolucion")]
        public async Task<ActionResult<Unit>> SeedProductos()
        {
            return await Mediator.Send(new SeederDevolucion.Insertadevolucion());
        }
        
    }
}