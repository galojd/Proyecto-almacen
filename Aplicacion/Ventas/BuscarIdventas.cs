using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Ventas
{
    public class BuscarIdventas
    {
        public class Ejecuta: IRequest<Venta>{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, Venta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Venta> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var venta = await _contexto.Venta!.FindAsync(request.Id);
                if(venta == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el cliente que buscaba"});
                }
                return venta;
            }
        }
    }
}