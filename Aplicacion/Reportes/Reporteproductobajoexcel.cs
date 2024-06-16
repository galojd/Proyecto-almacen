using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Reportes
{
    public class Reportesproductobajoexcel
    {
        public class ListaReporte : IRequest<byte[]>{}
        public class Manejador : IRequestHandler<ListaReporte, byte[]>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<byte[]> Handle(ListaReporte request, CancellationToken cancellationToken)
            {
                var reportestock = await _contexto.Producto!
                                    .Where(p => (p.DetalleInventariolista.FirstOrDefault().StockTotal ?? 0) < (p.StockMinimo ?? 0))
                                    .Include(p => p.Categoria)
                                    .Include(p => p.DetalleInventariolista)
                                        .ThenInclude(di => di.Inventario)
                                        .Select(p => new ReporteStockBajo
                                        {
                                            Id = p.ProductoId,
                                            NombreProducto = p.Nombre,
                                            Descripcion = p.Descripcion,
                                            Comentario = "El producto se debe reponer, no cumple el umbral establecido"
                                        })
                                        .ToListAsync(cancellationToken);

                var dt = new DataTable();

                dt.TableName = "Reporte-producto-bajo";
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("Nombre del producto", typeof(string));
                dt.Columns.Add("Descripcion del producto", typeof(string));
                dt.Columns.Add("Comentario", typeof(string));

                reportestock.ForEach(c => {
                    dt.Rows.Add(
                        c.Id, 
                        c.NombreProducto, 
                        c.Descripcion,
                        c.Comentario
                    );
                });

                using(var wb = new XLWorkbook()) {
                    wb.AddWorksheet(dt, "Reporte de productos bajos");

                    using(var ms = new MemoryStream()) {
                        wb.SaveAs(ms);

                        return ms.ToArray();
                    }
                }
            }
        }
    }
}