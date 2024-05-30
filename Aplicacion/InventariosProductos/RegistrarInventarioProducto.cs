using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.InventariosProductos
{
    public class RegistrarInventarioProducto
    {
        public class Ejecuta : IRequest
        {
            public DateTime? Fechaentrega{ get; set; }
            public decimal? Descuento{ get;set; }
            public int? Cantidad{ get;set;}
            public decimal? PrecioTotal{ get; set; }
            public Guid? InventarioId{ get; set; }
            public Guid? ProductoProveedorId{ get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _inventarioProductoid = Guid.NewGuid();
                var inventarioProducto = new InventarioProducto{
                    InventarioProductoId = _inventarioProductoid,
                    Cantidad = request.Cantidad,
                    Fechaentrega = request.Fechaentrega,
                    Descuento = request.Descuento,
                    PrecioTotal = request.PrecioTotal,
                    InventarioId = request.InventarioId,
                    ProductoProveedorId = request.ProductoProveedorId
                };
                _contexto.InventarioProducto!.Add(inventarioProducto);
                
                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el registro");
            }
        }


    }
}