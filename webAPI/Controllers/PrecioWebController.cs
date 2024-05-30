using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.PreciosWeb;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
     // http://localhost:5235/api/PrecioWeb
    public class PrecioWebController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(RegistrarPrecioweb.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<PrecioWeb>>> Get(){
            
            return await Mediator.Send(new ConsultaPrecioweb.Listaprecioweb());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrecioWeb>> buscaidcomprapago(Guid id){
           
            return await Mediator.Send(new BuscaIdPrecioweb.Ejecuta{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditaPrecioweb.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);    
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new EliminarPrecioweb.Ejecuta{Id = id});
            
        }
        
    }
}