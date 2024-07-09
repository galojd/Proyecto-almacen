using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Ventas
{
    public class Consultaventa
    {
        public class ListaVentas : IRequest<List<VentaDto>> { }

        public class Manejador : IRequestHandler<ListaVentas, List<VentaDto>>
        {
            private readonly AlmacenOnlineContext _contexto;
            private readonly  IMapper _mapper;

            public Manejador(AlmacenOnlineContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<VentaDto>> Handle(ListaVentas request, CancellationToken cancellationToken)
            {
                var venta = await _contexto.Venta!
                .Include(x => x.DetallePedidolista)
                .ThenInclude(d => d.Producto)
                .ToListAsync(cancellationToken);
                var ventasdto = _mapper.Map<List<Venta>, List<VentaDto>>(venta);
                return ventasdto;
            }
        }
    }
}