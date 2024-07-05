using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Devoluciones
{
    public class ConsultaDevolucion
    {

        public class Listadevolucion : IRequest<List<devolucionDTO>> { }

        public class Manejador : IRequestHandler<Listadevolucion, List<devolucionDTO>>
        {
            private readonly AlmacenOnlineContext _contexto;
            private readonly IMapper _mapper;

            public Manejador(AlmacenOnlineContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<devolucionDTO>> Handle(Listadevolucion request, CancellationToken cancellationToken)
            {

                var devolucion = await _contexto.Devolucion!
                                .Include(d => d.DetallePedido)
                                .ThenInclude(dp => dp!.Producto)
                                .Select(d => new devolucionDTO
                                {
                                    DevolucionId = d.DevolucionId,
                                    Cantidad = d.Cantidad,
                                    FechaDevolucion = d.FechaDevolucion,
                                    Descripcion = d.Descripcion,
                                    DetallePedidoId = d.DetallePedidoId,
                                    productodevuelto = d.DetallePedido.Producto!.Nombre
                                })
                                .ToListAsync();
                return devolucion;
            }
        }
    }
}