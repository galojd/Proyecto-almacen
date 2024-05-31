using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Reportes
{
    public class ReporteProductos
    {
        public class ListaReporte : IRequest<List<Reportes>>{}

        public class Manejador : IRequestHandler<ListaReporte, List<Reportes>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<List<Reportes>> Handle(ListaReporte request, CancellationToken cancellationToken)
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
                return reporteproductos;
            }
        }
    }
}