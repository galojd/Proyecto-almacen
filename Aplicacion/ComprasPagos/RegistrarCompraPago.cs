using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.ComprasPagos
{
    public class RegistrarCompraPago
    {
        public class Ejecuta : IRequest
        {
            public DateTime? FechaPago{ get; set; }      
            public Decimal? MontoPago{ get; set; }
            public Guid MetodoPagoId{get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _CompraPago = Guid.NewGuid();
                var comprapago = new CompraPago{
                    CompraPagoId = _CompraPago,
                    FechaPago = DateTime.UtcNow,
                    MontoPago = request.MontoPago,
                    MetodoPagoId = request.MetodoPagoId
                };
                _contexto.CompraPago!.Add(comprapago);

                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el registro");
            }
        }
    }
}