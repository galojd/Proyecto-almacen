using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.PreciosWebProductos
{
    public class Consultawebproducto
    {
        public class Listawebproducto : IRequest<List<PrecioWebProducto>>{}

        public class Manejador : IRequestHandler<Listawebproducto, List<PrecioWebProducto>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<List<PrecioWebProducto>> Handle(Listawebproducto request, CancellationToken cancellationToken)
            {
                var precioweb = await _contexto.PrecioWebProducto!.ToListAsync();
                return precioweb;
            }
        }
    }
}