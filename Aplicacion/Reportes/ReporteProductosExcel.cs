using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Irony.Parsing;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Reportes
{
    public class ReporteProductosExcel
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
                var reporteproductos = await _contexto.Producto
                                        .Include(p => p.Categoria)
                                        .Include(p => p.DetalleInventariolista)
                                        .ThenInclude(di => di.Inventario)
                                        .ThenInclude(i => i!.Proveedor)
                                        .Include(p => p.DetallePedidolista)
                                        .ThenInclude(dp => dp.Devolucionlista)
                                        .Select(p => new Reportes
                                        {
                                            Id = p.ProductoId,
                                            NombreProducto = p.Nombre,
                                            Descripcion = p.Descripcion,
                                            PrecioUnitario = p.PrecioUnitario,
                                            FechaActualizacion = p.FechaActualizacion,
                                            Categoria = p.Categoria!.NombreCategoria,
                                            //PrecioTotal = p.DetalleInventariolista.FirstOrDefault().Precio,
                                            Stocktotal = p.DetalleInventariolista.FirstOrDefault().StockTotal,
                                            Fechaentrada = p.DetalleInventariolista.FirstOrDefault().Inventario.FechaEntrada,
                                            NombreProveedor = p.DetalleInventariolista.FirstOrDefault().Inventario.Proveedor.Nombre,
                                            DescripcionInventario = p.DetalleInventariolista.FirstOrDefault().Descripcion,
                                            Cantidad = p.DetalleInventariolista.FirstOrDefault().Inventario.CantidadProducto ?? 0,
                                            PrecioTotal = p.PrecioUnitario * (p.DetalleInventariolista.FirstOrDefault().Inventario.CantidadProducto ?? 0),
                                            DescripcionDevolucion = p.DetallePedidolista.FirstOrDefault().Devolucionlista.FirstOrDefault().Descripcion,
                                            Fechadevolucion = p.DetallePedidolista.FirstOrDefault().Devolucionlista.FirstOrDefault().FechaDevolucion,
                                            Devolucioncantidad = p.DetallePedidolista.FirstOrDefault().Devolucionlista.FirstOrDefault().Cantidad
                                        })
                                        .ToListAsync(cancellationToken);
                
                
                var dt = new DataTable();

                dt.TableName = "Reporte";

                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("Nombre del producto", typeof(string));
                dt.Columns.Add("Descripcion del producto", typeof(string));
                dt.Columns.Add("Stock total", typeof(int));
                dt.Columns.Add("Precio unitario", typeof(decimal));
                dt.Columns.Add("Fecha de actualización", typeof(string));
                dt.Columns.Add("Categoría", typeof(string));
                dt.Columns.Add("Precio total", typeof(decimal));
                dt.Columns.Add("Nombre del proveedor", typeof(string));
                dt.Columns.Add("Fecha de entrada", typeof(string));
                dt.Columns.Add("Descripción de invertario", typeof(string));
                dt.Columns.Add("Cantidad de ingreso", typeof(int));
                dt.Columns.Add("Cantidad de devoluciones", typeof(int));
                dt.Columns.Add("Fecha de devolución", typeof(string));
                dt.Columns.Add("Descripción de devolución", typeof(string));

                reporteproductos.ForEach(c => {
                    dt.Rows.Add(
                        c.Id, 
                        c.NombreProducto, 
                        c.Descripcion,
                        c.Stocktotal,
                        c.PrecioUnitario,
                        c.FechaActualizacion,
                        c.Categoria,
                        c.PrecioTotal,
                        c.NombreProveedor,
                        c.Fechaentrada,
                        c.DescripcionInventario,
                        c.Cantidad,
                        c.Devolucioncantidad,
                        c.Fechadevolucion,
                        c.DescripcionDevolucion
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