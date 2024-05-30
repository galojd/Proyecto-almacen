using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.DetallePedidos
{
    public class EditarDetallepedido
    {
        public class Ejecuta : IRequest
        {
            public Guid Id{ get; set; }
            public int? Cantidad{ get; set; }
            public decimal? Precio{ get;set;}
            public DateTime? FechaPedido{ get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var detallepedido = await _contexto.DetallePedido!.FindAsync(request.Id);
                if(detallepedido == null){
                    throw new Exception("No se puede encontrar el registro");
                }
                detallepedido.Cantidad = request.Cantidad ?? detallepedido.Cantidad;
                detallepedido.Precio = request.Precio ?? detallepedido.Precio;
                detallepedido.FechaPedido = DateTime.UtcNow;
                
                var resultado = await _contexto.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo modificar el registro");
            }
        }
    }
}