using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;


namespace Aplicacion.DetalleInventarios
{
    public class BuscaIddetalleinventario
    {
        public class Ejecuta: IRequest<DetalleInventario>{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, DetalleInventario>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<DetalleInventario> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var detalleinventario = await _contexto.DetalleInventario!.FindAsync(request.Id);
                if(detalleinventario == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                return detalleinventario;
            }
        }
        
    }
}