using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.ComprasPagos
{
    public class RegistrarCompraPago
    {
        public class Ejecuta : IRequest<string>
        {
            public DateTime? FechaPago{ get; set; }      
            public Decimal? MontoPago{ get; set; }
            public Guid MetodoPagoId{get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
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
                    return "la creación fue exitosa";
                }
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo insertar el registro" });  
            }
        }
    }
}