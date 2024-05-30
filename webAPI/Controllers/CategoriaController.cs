using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Categorias;
using Aplicacion.Clientes;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    // http://localhost:5235/api/Categoria
    public class CategoriaController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(RegistrarCategoria.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get(){
            
            return await Mediator.Send(new ConsultaCategoria.Listacategoria());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> buscaidcate(Guid id){
           
            return await Mediator.Send(new BuscaIdCategoria.Ejecuta{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarCategoria.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);    
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
           
            return await Mediator.Send(new EliminarCategoria.Ejecuta{Id = id});
            
        }
    }
}