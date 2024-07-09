using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Devoluciones
{
    public class BuscaIdDevolucion
    {
        public class Ejecuta: IRequest<Devolucion>{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, Devolucion>
        {
             private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<Devolucion> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var devolucion = await _contexto.Devolucion!.FindAsync(request.Id);
                if(devolucion == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                return devolucion;
            }
        }
    }
}