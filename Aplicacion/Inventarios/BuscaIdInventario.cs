using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Inventarios
{
    public class BuscaIdInventario
    {
        public class Ejecuta: IRequest<Inventario>{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, Inventario>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Inventario> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var inventario = await _contexto.Inventario!.FindAsync(request.Id);
                if(inventario == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                return inventario;
            }
        }

    }
}