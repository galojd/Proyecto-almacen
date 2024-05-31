using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Productos
{
    public class EditarProducto
    {
        public class Ejecuta : IRequest
        {
            public Guid Id{ get; set; }
            public string? Nombre{get;set;}
            public string? Descripcion{get;set;}
            public decimal? PrecioUnitario{get;set;}
            public DateTime? FechaActualizacion{get;set;}
            public int? StockMinimo{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var producto = await _contexto.Producto!.FindAsync(request.Id);
                if(producto == null){
                    throw new Exception("No se puede encontrar el registro");
                }
                producto.Nombre = request.Nombre ?? producto.Nombre;
                producto.Descripcion = request.Descripcion ?? producto.Descripcion;
                producto.PrecioUnitario = request.PrecioUnitario ?? producto.PrecioUnitario;
                producto.FechaActualizacion = DateTime.UtcNow;
                producto.StockMinimo = request.StockMinimo ?? producto.StockMinimo;
                
                var resultado = await _contexto.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo modificar el registro");
            }
        }
    }
}