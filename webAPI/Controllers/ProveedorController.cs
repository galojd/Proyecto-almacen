using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Proveedores;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    public class ProveedorController : Micontrollerbase
    {
        // http://localhost:5235/api/Proveedor
        [HttpPost]
        public async Task<ActionResult<string>> Crear(RegistraProveedor.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<Proveedor>>> Get(){
            
            return await Mediator.Send(new ConsultaProveedor.Listaproveedor());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> buscaproveedor(Guid id){
           
            return await Mediator.Send(new BuscaIdProveedor.Ejecuta{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditaProveedor.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);    
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new EliminaProveedor.Ejecuta{Id = id});
            
        }

        // Endpoint para insertar múltiples productos aleatorios
        [HttpPost("seedproveedor")]
        public async Task<ActionResult<Unit>> SeedProductos()
        {
            return await Mediator.Send(new SeedProveedores.InsertaProveedores());
        }
        
    }
}