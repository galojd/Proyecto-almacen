using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ComprasPagos
{
    public class ConsultaCompraPago
    {
        public class ListaCompraPago : IRequest<List<CompraPago>>{}
        public class Manejador : IRequestHandler<ListaCompraPago, List<CompraPago>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<List<CompraPago>> Handle(ListaCompraPago request, CancellationToken cancellationToken)
            {
                var comprapago = await _contexto.CompraPago!.ToListAsync();
                return comprapago;
            }
        }
    }
}