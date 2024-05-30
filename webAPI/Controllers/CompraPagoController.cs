using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.ComprasPagos;
using Aplicacion.Ventas;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    // http://localhost:5235/api/CompraPago
    public class CompraPagoController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(RegistrarCompraPago.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<CompraPago>>> Get(){
            
            return await Mediator.Send(new ConsultaCompraPago.ListaCompraPago());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompraPago>> buscaidcomprapago(Guid id){
           
            return await Mediator.Send(new BuscaIdCompraPago.Ejecuta{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarCompraPago.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);    
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new EliminarCompraPago.Ejecuta{Id = id});
            
        }
    }
}