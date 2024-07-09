using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Ventas
{
    public class FiltrarVenta
    {
        public class ListaVentas : IRequest<List<VentaFiltrada>> { }

        public class Manejador : IRequestHandler<ListaVentas, List<VentaFiltrada>>
        {
            private readonly AlmacenOnlineContext _contexto;
            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<List<VentaFiltrada>> Handle(ListaVentas request, CancellationToken cancellationToken)
            {
                var venta = await _contexto.Venta
                            .Include(x => x.Cliente)
                            .Include(x => x.DetallePedidolista)
                            .ThenInclude(dp => dp.Producto)
                            .Select( x => new VentaFiltrada{
                                VentaId = x.VentaId,
                                Fecha = x.Fecha,
                                PrecioTotal = x.PrecioTotal,
                                Descripcion = x.Descripcion,
                                ClienteId = x.ClienteId,
                                Nombrecliente = x.Cliente!.Nombres,
                                NombreProducto = x.DetallePedidolista.FirstOrDefault().Producto!.Nombre
                            })
                            .ToListAsync(cancellationToken);
                
                return venta;
            }
        }
    }
}