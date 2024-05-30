using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Clientes
{
    public class BuscarId
    {
        public class Ejecuta: IRequest<Cliente>{
            public Guid ClienteId{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, Cliente>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<Cliente> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var clientedb = await _contexto.Cliente!.FindAsync(request.ClienteId);
                if(clientedb == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el cliente que buscaba"});
                }
                return clientedb;
            }
        }
    }
}