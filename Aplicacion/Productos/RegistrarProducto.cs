using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Productos
{
    public class RegistrarProducto
    {
        public class Ejecuta : IRequest<string>
        {
            public string? Nombre { get; set; }
            public string? Descripcion { get; set; }
            public decimal? PrecioUnitario { get; set; }
            public DateTime? FechaCreacion { get; set; }
            public int? StockMinimo { get; set; }
            public Guid? CategoriaId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var productoregistrado = await _contexto.Producto!
                                            .FirstOrDefaultAsync(p => p.Nombre == request.Nombre, cancellationToken);

                if (productoregistrado != null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.Conflict, new { mensaje = "El producto con este nombre ya existe." }); 
                }

                Guid _productoid = Guid.NewGuid();
                var producto = new Producto
                {
                    ProductoId = _productoid,
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion,
                    PrecioUnitario = request.PrecioUnitario,
                    FechaCreacion = DateTime.UtcNow,
                    StockMinimo = request.StockMinimo,
                    CategoriaId = request.CategoriaId
                };

                _contexto.Producto!.Add(producto);

                var valor = await _contexto.SaveChangesAsync();
                if (valor > 0)
                {
                    return "la creación fue exitosa";
                }
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo insertar el registro" });  
            }
        }
    }
}