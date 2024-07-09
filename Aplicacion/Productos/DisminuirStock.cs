using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using Aplicacion.ManejadorError;
using System.Net;

namespace Aplicacion.Productos
{
    public class DisminuirStock
    {
        public class Ejecuta : IRequest<string>
        {
            public string? NombreProducto { get; set; }
            public int? cantidad { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var producto = await _contexto.Producto!
                                            .FirstOrDefaultAsync(p => p.Nombre == request.NombreProducto, cancellationToken);
                if(producto == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                var codigoproducto = producto.ProductoId;
                var preciounico = producto.PrecioUnitario;
                var detalleinventario = await _contexto.DetalleInventario!.FirstOrDefaultAsync(p => p.ProductoId == codigoproducto, cancellationToken);
                
                if(detalleinventario == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se tiene un registro asociado"});
                }

                var ahora = 0;
                var stockantes = detalleinventario.StockTotal;
                var stocktodo = stockantes - request.cantidad;
                var preciototal = preciounico * stocktodo;
                detalleinventario.StockAnterior = stockantes ?? detalleinventario.StockAnterior;
                detalleinventario.StockIngreso = ahora;
                detalleinventario.StockTotal = stocktodo ?? detalleinventario.StockTotal;
                detalleinventario.Precio = preciototal ?? detalleinventario.Precio;

                var resultado = await _contexto.SaveChangesAsync();
                if (resultado > 0)
                {
                    return "Se realizo su petición de forma satisfactoria";
                }
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo realizar su petición" });
            }
        }

    }
}