using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.ComprasPagos
{
    public class EditarCompraPago
    {
        public class Ejecuta : IRequest
        {
            public Guid Id{ get; set; }
            public DateTime? FechaPago{ get; set; }      
            public Decimal? MontoPago{ get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var comprapago = await _contexto.CompraPago!.FindAsync(request.Id);
                if(comprapago == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "No se puede encontrar el registro" });
                }

                comprapago.MontoPago = request.MontoPago ?? comprapago.MontoPago;
                comprapago.FechaPago = DateTime.UtcNow;

                var resultado = await _contexto.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo editar el registro" }); 
            }
        }
    }
}