using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Productos
{
    public class BuscaIdProducto
    {
        public class Ejecuta: IRequest<Producto>{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, Producto>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Producto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var producto = await _contexto.Producto!.FindAsync(request.Id);
                if(producto == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                return producto;
            }
        }
    }
}