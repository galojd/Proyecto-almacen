using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Reportes
{
    public class ReportestockBajos
    {
        public class ListaReportebajo : IRequest<List<ReporteStockBajo>>{}

        public class Manejador : IRequestHandler<ListaReportebajo, List<ReporteStockBajo>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<List<ReporteStockBajo>> Handle(ListaReportebajo request, CancellationToken cancellationToken)
            {
                var reportestock = await _contexto.Producto
                                    .Include(p => p.Categoria)
                                    .Include(p => p.DetalleInventariolista)
                                        .ThenInclude(di => di.Inventario)
                                        .Select(p => new ReporteStockBajo
                                        {
                                            Id = p.ProductoId,
                                            NombreProducto = p.Nombre,
                                            Descripcion = p.Descripcion,
                                            StockMinimo = p.StockMinimo,
                                            Stocktotal = p.DetalleInventariolista.FirstOrDefault().StockTotal,
                                            Comentario = (p.DetalleInventariolista.FirstOrDefault().StockTotal ?? 0) < (p.StockMinimo ?? 0)
                                                            ? "El stock del producto es bajo, es necesario reponer"
                                                            : "Stock suficiente"
                                        })
                                        .ToListAsync(cancellationToken);
                                    
                return reportestock;
            }
        }


    }
}