using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Inventarios;
using Aplicacion.Productos;
using Aplicacion.Reportes;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    public class ProductoController : Micontrollerbase
    {
        // http://localhost:5235/api/Producto
        [HttpPost]
        public async Task<ActionResult<string>> Crear(RegistrarProducto.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDTO>>> Get()
        {

            return await Mediator.Send(new ConsultaProducto.ListaProducto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> buscaidcomprapago(Guid id)
        {

            return await Mediator.Send(new BuscaIdProducto.Ejecuta { Id = id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarProducto.Ejecuta data)
        {
            data.Id = id;
            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {

            return await Mediator.Send(new EliminarProducto.Ejecuta { Id = id });

        }

        // Endpoint para insertar múltiples productos aleatorios
        [HttpPost("seedproductos")]
        public async Task<ActionResult<Unit>> SeedProductos()
        {
            return await Mediator.Send(new SeedProducto.InsertaProductos());
        }

        //Con este api aumento la cantidad de productos registrados en el inventario
        [HttpPost("IngresarCantidad/{nombre}")]
        public async Task<ActionResult<string>> busquedaproducto(string nombre, Aumentarstock.Ejecuta data)
        {
            if (data == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");
            }
            data.NombreProducto = nombre;
            return await Mediator.Send(data);
        }

        //Con este api disminuyo la cantidad de productos registrados en el inventario
        [HttpPost("DisminuirCantidad/{nombre}")]
        public async Task<ActionResult<string>> busquedaproducto(string nombre, DisminuirStock.Ejecuta data)
        {
            if (data == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");
            }
            data.NombreProducto = nombre;
            return await Mediator.Send(data);
        }

    }
}