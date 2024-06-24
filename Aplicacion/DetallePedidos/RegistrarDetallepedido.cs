using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;


namespace Aplicacion.DetallePedidos
{
    public class RegistrarDetallepedido
    {
        public class Ejecuta : IRequest<string>
        {
            public int? Cantidad{ get; set; }
            public decimal? Precio{ get;set;}
            public DateTime? FechaPedido{ get; set; }
            public Guid? ProductoId{ get; set; }
            public Guid VentaId{ get; set; }
           
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _detallepedidoid = Guid.NewGuid();
                var detallepedido = new DetallePedido{
                    DetallePedidoId = _detallepedidoid,
                    Cantidad = request.Cantidad,
                    Precio = request.Precio,
                    ProductoId = request.ProductoId,
                    VentaId = request.VentaId,
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