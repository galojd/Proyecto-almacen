using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;


namespace Aplicacion.InventariosProductos
{
    public class Consultainventarioproducto
    {
        public class ListainventarioProducto : IRequest<List<InventarioProducto>>{}

        public class Manejador : IRequestHandler<ListainventarioProducto, List<InventarioProducto>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<List<InventarioProducto>> Handle(ListainventarioProducto request, CancellationToken cancellationToken)
            {
                var inventarioProducto = await _contexto.InventarioProducto!.ToListAsync();
                return inventarioProducto;
            }
        }
    }
}