using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Aplicacion.Inventarios;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Productos
{
    public class ConsultaProducto
    {
        public class ListaProducto : IRequest<List<ProductoDTO>>{}
        public class Manejador : IRequestHandler<ListaProducto, List<ProductoDTO>>
        {
            private readonly AlmacenOnlineContext _contexto;
            private readonly  IMapper _mapper;

            public Manejador(AlmacenOnlineContext contexto, IMapper mapper){
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<ProductoDTO>> Handle(ListaProducto request, CancellationToken cancellationToken)
            {
                var producto = await _contexto.Producto!.ToListAsync();
                var productodto = _mapper.Map<List<Producto>, List<ProductoDTO>>(producto);
                return productodto;
            }
        }
    }
}