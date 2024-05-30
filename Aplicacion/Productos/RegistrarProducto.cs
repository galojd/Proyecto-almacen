using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Productos
{
    public class RegistrarProducto
    {
        public class Ejecuta : IRequest
        {
            public string? Nombre{get;set;}
            public string? Descripcion{get;set;}
            public decimal? PrecioUnitario{get;set;}
            public DateTime? FechaCreacion{get;set;}
            public Guid? CategoriaId{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _productoid = Guid.NewGuid();
                var producto = new Producto{
                    ProductoId = _productoid,
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion,
                    PrecioUnitario = request.PrecioUnitario,
                    FechaCreacion = DateTime.UtcNow,
                    CategoriaId = request.CategoriaId
                };
                _contexto.Producto!.Add(producto);
                
                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el registro");
            }
        }
    }
}