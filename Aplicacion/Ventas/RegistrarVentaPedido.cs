using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Ventas
{
    public class RegistrarVentaPedido
    {
        public class Ejecuta : IRequest<string>
        {
            public string? Descripcion{ get; set; }
            public Guid ClienteId{ get; set; }
            public int? Cantidad{ get; set; }
            //public decimal? Precio{ get;set;}
            public Guid? ProductoId{ get; set; } 
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;
            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var producto = await _contexto.Producto!.FindAsync(request.ProductoId);
                if(producto == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                

                var preciounico = producto.PrecioUnitario;
                var Preciototal = preciounico * request.Cantidad; 

                Guid _ventaid = Guid.NewGuid();
                var venta = new Venta{
                    VentaId = _ventaid,
                    Fecha = DateTime.UtcNow,
                    PrecioTotal = Preciototal,
                    Descripcion = request.Descripcion,
                    ClienteId = request.ClienteId
                };
                _contexto.Venta!.Add(venta);

                Guid _detallepedidoid = Guid.NewGuid();
                var detallepedido = new DetallePedido{
                    DetallePedidoId = _detallepedidoid,
                    Cantidad = request.Cantidad,
                    Precio = preciounico,
                    ProductoId = request.ProductoId,
                    VentaId = _ventaid,
                    FechaPedido = DateTime.UtcNow
                };
                _contexto.DetallePedido!.Add(detallepedido);
                
                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return "la creación fue exitosa";
                }
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo insertar el registro" });  
            }

        }

        
    }
}