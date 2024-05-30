using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.DetallePedidos
{
    public class BuscaIdDetallepedido
    {
        public class Ejecuta: IRequest<DetallePedido>{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, DetallePedido>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<DetallePedido> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var detallepedido = await _contexto.DetallePedido!.FindAsync(request.Id);
                if(detallepedido == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                return detallepedido;
            }
        }
    }
}