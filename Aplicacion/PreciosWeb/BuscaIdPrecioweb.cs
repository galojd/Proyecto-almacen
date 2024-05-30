using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.PreciosWeb
{
    public class BuscaIdPrecioweb
    {
        public class Ejecuta: IRequest<PrecioWeb>{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, PrecioWeb>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<PrecioWeb> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                
                var precioweb = await _contexto.PrecioWeb!.FindAsync(request.Id);
                if(precioweb == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                return precioweb;
            }
        }
    }
}