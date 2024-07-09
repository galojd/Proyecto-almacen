using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.InventariosProductos
{
    public class BuscaIdinventarioproducto
    {
        public class Ejecuta: IRequest<InventarioProducto>{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, InventarioProducto>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<InventarioProducto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var inventarioProducto = await _contexto.InventarioProducto!.FindAsync(request.Id);
                if(inventarioProducto == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                return inventarioProducto;
            }
        }
        
    }
}