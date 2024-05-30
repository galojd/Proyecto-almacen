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
            public Task<List<Reportes>> Handle(ListaReporte request, CancellationToken cancellationToken)
            {
                var reporteproductos = (from producto in _contexto.Producto
                                 join detalleInventario in _contexto.DetalleInventario! on producto.ProductoId equals detalleInventario.ProductoId
                                 join inventario in _contexto.Inventario! on detalleInventario.InventarioId equals inventario.InventarioId
                                 join proveedor in _contexto.Proveedor! on inventario.ProveedorId equals proveedor.ProveedorId
                                 select new Reportes
                                 {
                                     NombreProducto = producto.Nombre,
                                     Descripcion = producto.Descripcion,
                                     Precio = detalleInventario.Precio,
                                     Stocktotal = detalleInventario.StockTotal,
                                     Fechaentrada = inventario.FechaEntrada,
                                     NombreProveedor = proveedor.Nombre
                                 }).ToListAsync(cancellationToken);
                return reporteproductos;
            }
        }
    }
}