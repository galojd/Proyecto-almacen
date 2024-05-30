using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Metododepagos;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// http://localhost:5235/api/MostrarMetodo
namespace webAPI.Controllers
{
    public class MostrarMetodoController: Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(RegistrarMetodo.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<MetodoPago>>> Get(){
            
            return await Mediator.Send(new Mostrarmetodo.ListaMetodopago());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new EliminarMetodo.Ejecuta{Id = id});
            
        }
    }
}