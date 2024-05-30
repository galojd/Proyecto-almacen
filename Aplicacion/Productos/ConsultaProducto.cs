using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Productos
{
    public class ConsultaProducto
    {
        public class ListaProducto : IRequest<List<Producto>>{}
        public class Manejador : IRequestHandler<ListaProducto, List<Producto>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<List<Producto>> Handle(ListaProducto request, CancellationToken cancellationToken)
            {
                var producto = await _contexto.Producto!.ToListAsync();
                return producto;
            }
        }
    }
}