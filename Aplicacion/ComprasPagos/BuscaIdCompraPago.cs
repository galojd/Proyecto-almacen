using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.ComprasPagos
{
    public class BuscaIdCompraPago
    {
        public class Ejecuta: IRequest<CompraPago>{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, CompraPago>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<CompraPago> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var comprapago = await _contexto.CompraPago!.FindAsync(request.Id);
                if(comprapago == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                return comprapago;
            }
        }
    }
}