using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.DetallePedidos
{
    public class MostrarDetallePedidoNombre
    {
        
        public class ListaVentas : IRequest<List<DetallePedidoNombre>> { }

        public class Manejador : IRequestHandler<ListaVentas, List<DetallePedidoNombre>>
        {
            private readonly AlmacenOnlineContext _contexto;
            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public Task<List<DetallePedidoNombre>> Handle(ListaVentas request, CancellationToken cancellationToken)
            {
                var detallenombre = _contexto.DetallePedido!
                                    .Include(d => d.Producto)
                                    .Select(d => new DetallePedidoNombre{
                                        DetallePedidoId = d.DetallePedidoId,
                                        Cantidad = d.Cantidad,
                                        ProductoId = d.ProductoId,
                                        NombreProducto = d.Producto!.Nombre
                                    })
                                    .ToListAsync(cancellationToken);
                return detallenombre;
            }
        }
    }
}