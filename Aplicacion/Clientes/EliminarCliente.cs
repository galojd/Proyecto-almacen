using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Clientes
{
    public class EliminarCliente
    {
        public class Ejecuta: IRequest{
            public Guid ClienteId{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var clientedb = await _contexto.Cliente!.FindAsync(request.ClienteId);
    
                if (clientedb == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }

                // Buscar y eliminar ventas asociadas al cliente
                var ventasCliente = _contexto.Venta!.Where(v => v.ClienteId == request.ClienteId).ToList();
                foreach (var venta in ventasCliente)
                {
                    var detallesVenta = _contexto.DetallePedido!.Where(d => d.VentaId == venta.VentaId).ToList();
                    foreach (var detalle in detallesVenta)
                    {
                        var devolucionesDetalle = _contexto.Devolucion!.Where(dev => dev.DetallePedidoId == detalle.DetallePedidoId).ToList();
                        _contexto.Devolucion!.RemoveRange(devolucionesDetalle);
                        _contexto.DetallePedido!.Remove(detalle);
                    }
                    _contexto.Venta!.Remove(venta);
                }

                _contexto.Cliente.Remove(clientedb);

                var resultado = await _contexto.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo eliminar el registro" });  


            }
        }
    }
}