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
    // http://localhost:5235/api/RegistraDetalle
    public class RegistraDetalleController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Crear(Registradetalleinventario.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<DetalleInventario>>> Get(){
            
            return await Mediator.Send(new Consultadetalleinventario.Listadetalleinventario());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleInventario>> buscaiddetalle(Guid id){
           
            return await Mediator.Send(new BuscaIddetalleinventario.Ejecuta{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditaDetalleinventario.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);    
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new Eliminardetalleinventario.Ejecuta{Id = id});
            
        }
        
    }
}