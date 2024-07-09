using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.PreciosWebProductos
{
    public class BuscaIdwebproducto
    {
        public class Ejecuta: IRequest<PrecioWebProducto>{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, PrecioWebProducto>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<PrecioWebProducto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var webpriducto = await _contexto.PrecioWebProducto!.FindAsync(request.Id);
                if(webpriducto == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                return webpriducto;
            }
        }
    }
}