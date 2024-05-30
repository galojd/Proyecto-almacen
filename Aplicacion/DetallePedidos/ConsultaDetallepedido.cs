using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.DetallePedidos
{
    public class ConsultaDetallepedido
    {
        public class ListaDetallepedido : IRequest<List<DetallePedido>>{}
        public class Manejador : IRequestHandler<ListaDetallepedido, List<DetallePedido>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<List<DetallePedido>> Handle(ListaDetallepedido request, CancellationToken cancellationToken)
            {
                var detallepedido = await _contexto.DetallePedido!.ToListAsync();
                return detallepedido;
            }
        }

    }
}