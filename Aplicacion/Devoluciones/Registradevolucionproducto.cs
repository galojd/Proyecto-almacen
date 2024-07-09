using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Dominio.entities;
using MediatR;
using Aplicacion.ManejadorError;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Devoluciones
{
    public class Registradevolucionproducto
    {
        public class Ejecuta : IRequest<string>
        {
            public int? Cantidad{get;set;}
            public string? Descripcion{get;set;}
            public string? NombreProducto{get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var producto = await _contexto.Producto!.FirstOrDefaultAsync(p => p.Nombre == request.NombreProducto, cancellationToken);
                if (producto == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.Conflict, new { mensaje = "Producto no encontrado." }); 
                }

                var detallePedido = await _contexto.DetallePedido!.FirstOrDefaultAsync(dp => dp.ProductoId == producto.ProductoId, cancellationToken);

                if (detallePedido == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.Conflict, new { mensaje = "detallepedido no encontrado." }); 
                }

                Guid _devolucionid = Guid.NewGuid();
                var devolucion = new Devolucion{
                    DevolucionId = _devolucionid,
                    Cantidad = request.Cantidad,
                    FechaDevolucion = DateTime.UtcNow,
                    Descripcion = request.Descripcion,
                    DetallePedidoId = detallePedido.DetallePedidoId
                };
                _contexto.Devolucion!.Add(devolucion);

                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return "la creación fue exitosa";
                }
                throw new Exception("No se pudo insertar el registro");
            }
        }
    }
}