using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Clientes;
using Aplicacion.Seguridad;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    
    public class ClienteController : Micontrollerbase
    {
        // http://localhost:5235/api/Cliente
        //registrar cliente
        [HttpPost]
        public async Task<ActionResult<string>> Crear(RegistrarCliente.ejecuta data){
            return await Mediator.Send(data);
        }
        
        //mostrar cliente
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get(){
            //se llama al mediador para que me devuelva la data de curso
            return await Mediator.Send(new Consulta.ListaClientes());

        }

        //Mostrar cliente por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> buscaid(Guid id){
            //se llama al mediador para que me devuelva la data de cliente
            return await Mediator.Send(new BuscarId.Ejecuta{ClienteId = id});
        }


        //Actualizar cliente
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarCliente.Ejecuta data){
            
            data.ClienteId = id;
            return await Mediator.Send(data);
            
        }

        //Eliminar cliente
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new EliminarCliente.Ejecuta{ClienteId = id});
            
        }

    }
}