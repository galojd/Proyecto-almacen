using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Ventas
{
    public class Eliminarventa
    {
        public class Ejecuta: IRequest{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
             private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                // Buscar y eliminar detalles de pedido asociados a la venta
                var detallesVenta = await _contexto.DetallePedido!
                    .Where(d => d.VentaId == request.Id)
                    .ToListAsync(cancellationToken);

                foreach (var detalle in detallesVenta)
                {
                    // Buscar y eliminar devoluciones asociadas al detalle de pedido
                    var devolucionesDetalle = await _contexto.Devolucion!
                        .Where(dev => dev.DetallePedidoId == detalle.DetallePedidoId)
                        .ToListAsync(cancellationToken);

                    _contexto.Devolucion!.RemoveRange(devolucionesDetalle);
                    _contexto.DetallePedido!.Remove(detalle);
                }

                // Buscar y eliminar la venta
                var venta = await _contexto.Venta!.FindAsync(request.Id);
                if (venta == null)
                {
                    throw new Exception("La venta no existe");
                }

                _contexto.Venta.Remove(venta);

                var resultado = await _contexto.SaveChangesAsync(cancellationToken);

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el registro"); 
            }
        }
    }
}