using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Productos
{
    public class StockProducto
    {
        public class Listacantidad : IRequest<List<NumeroStock>> { }

        public class Manejador : IRequestHandler<Listacantidad, List<NumeroStock>>
        {
            private readonly AlmacenOnlineContext _contexto;
            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<List<NumeroStock>> Handle(Listacantidad request, CancellationToken cancellationToken)
            {
                var cantidadproducto = await _contexto.Producto!
                                        .Include(p => p.DetalleInventariolista)
                                        .Select(p => new NumeroStock{
                                            ProductoId = p.ProductoId,
                                            Nombre = p.Nombre,
                                            StockTotal = p.DetalleInventariolista!.FirstOrDefault()!.StockTotal

                                        })
                                        .OrderByDescending(p => p.StockTotal)
                                        .Take(15)
                                        .ToListAsync(cancellationToken);
                return cantidadproducto;
            }
        }
    }
}