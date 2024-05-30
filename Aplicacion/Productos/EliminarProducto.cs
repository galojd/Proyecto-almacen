using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.Productos
{
    public class EliminarProducto
    {
        public class Ejecuta: IRequest{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                // Buscar y eliminar los detalles de pedido asociados al producto
                var detallesPedido = _contexto.DetallePedido!.Where(d => d.ProductoId == request.Id).ToList();
                foreach (var detalle in detallesPedido)
                {
                    // Buscar y eliminar las devoluciones asociadas al detalle de pedido
                    var devolucionesDetalle = _contexto.Devolucion!.Where(dev => dev.DetallePedidoId == detalle.DetallePedidoId).ToList();
                    _contexto.Devolucion!.RemoveRange(devolucionesDetalle);

                    _contexto.DetallePedido!.Remove(detalle);
                }

                //primero busco los detalleinventario ligados a Producto
                var detalleinventarioDB = _contexto.DetalleInventario!.Where(x => x.ProductoId == request.Id);
                //las elimino
                foreach(var inventario in detalleinventarioDB){
                    _contexto.DetalleInventario!.Remove(inventario);
                }

                //primero busco los detalleinventario ligados a Producto
                var preciowebDB = _contexto.PrecioWebProducto!.Where(x => x.ProductoId == request.Id);
                //las elimino
                foreach(var web in preciowebDB){
                    _contexto.PrecioWebProducto!.Remove(web);
                }

                // Buscar y eliminar el producto
                var producto = await _contexto.Producto!.FindAsync(request.Id);
                if (producto == null)
                {
                    throw new Exception("El registro no existe");
                }

                _contexto.Producto.Remove(producto);
                
                var resultado = await _contexto.SaveChangesAsync(cancellationToken);
                
                if (resultado > 0)
                {
                    return Unit.Value;
                } 
                
                throw new Exception("No se pudo eliminar el registro"); 
            }
        }
    }
}