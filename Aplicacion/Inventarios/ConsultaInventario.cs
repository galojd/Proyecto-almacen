using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Inventarios
{
    public class ConsultaInventario
    {
        public class Listainventario : IRequest<List<InventarioDTO>>{}

        public class Manejador : IRequestHandler<Listainventario, List<InventarioDTO>>
        {
            private readonly AlmacenOnlineContext _contexto;
            private readonly  IMapper _mapper;
            public Manejador(AlmacenOnlineContext contexto, IMapper mapper){
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<InventarioDTO>> Handle(Listainventario request, CancellationToken cancellationToken)
            {
                var inventario = await _contexto.Inventario
                    .Include(x => x.DetalleInventariolista)
                    .ThenInclude(d => d.Producto)
                    .ToListAsync(cancellationToken);
                var inventariodto = _mapper.Map<List<Inventario>, List<InventarioDTO>>(inventario);
                return inventariodto;
            }
        }
    }
}