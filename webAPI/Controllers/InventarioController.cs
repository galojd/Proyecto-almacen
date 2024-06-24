using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Inventarios;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    // http://localhost:5235/api/Inventario
    public class InventarioController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Crear(RegistrarInventario.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<InventarioDTO>>> Get(){
            
            return await Mediator.Send(new ConsultaInventario.Listainventario());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inventario>> buscaidinventario(Guid id){
           
            return await Mediator.Send(new BuscaIdInventario.Ejecuta{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditaInventario.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);    
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new EliminarInventario.Ejecuta{Id = id});
            
        }

        // Endpoint para insertar múltiples productos aleatorios
        [HttpPost("seedinventario")]
        public async Task<ActionResult<Unit>> SeedProductos()
        {
            return await Mediator.Send(new SeedInventario.InsertaInventario());
        }
        
    }
}