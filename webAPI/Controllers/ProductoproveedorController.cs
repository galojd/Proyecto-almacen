using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.ProductosProveedores;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    // http://localhost:5235/api/Productoproveedor
    public class ProductoproveedorController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Crear(RegistraProductoProveedor.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoProveedor>>> Get(){
            
            return await Mediator.Send(new Consultaproductoproveedor.Listaproductoproveedor());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoProveedor>> buscaidcomprapago(Guid id){
           
            return await Mediator.Send(new BuscaIdproductoproveedor.Ejecuta{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditaProductoProveedor.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);    
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new EliminaProductoProveedor.Ejecuta{Id = id});
            
        }
        
    }
}