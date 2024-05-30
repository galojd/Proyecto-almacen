using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Ventas
{
    public class Consultaventa
    {
        public class ListaVentas : IRequest<List<Venta>>{}

        public class Manejador : IRequestHandler<ListaVentas, List<Venta>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<List<Venta>> Handle(ListaVentas request, CancellationToken cancellationToken)
            {
                var ventas = await _contexto.Venta!.ToListAsync();
                return ventas;
            }
        }

    }
}