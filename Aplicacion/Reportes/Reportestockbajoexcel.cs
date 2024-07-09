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
    public class Reportestockbajoexcel
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
                                    .Include(p => p.Categoria)
                                    .Include(p => p.DetalleInventariolista)
                                        .ThenInclude(di => di.Inventario)
                                        .Select(p => new ReporteStockBajo
                                        {
                                            Id = p.ProductoId,
                                            NombreProducto = p.Nombre,
                                            Descripcion = p.Descripcion,
                                            Comentario = (p.DetalleInventariolista.FirstOrDefault().StockTotal ?? 0) < (p.StockMinimo ?? 0)
                                                            ? "El stock del producto es bajo, es necesario reponer"
                                                            : "Stock suficiente"
                                        })
                                        .ToListAsync(cancellationToken);

                var dt = new DataTable();

                dt.TableName = "Reporte-stock-bajo";
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
                    wb.AddWorksheet(dt, "Reporte de productos");

                    using(var ms = new MemoryStream()) {
                        wb.SaveAs(ms);

                        return ms.ToArray();
                    }
                }
            }
        }
    }
}