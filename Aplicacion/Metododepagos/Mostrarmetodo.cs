using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Metododepagos
{
    public class Mostrarmetodo
    {
        public class ListaMetodopago : IRequest<List<MetodoPago>>{}

        public class Manejador : IRequestHandler<ListaMetodopago, List<MetodoPago>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<List<MetodoPago>> Handle(ListaMetodopago request, CancellationToken cancellationToken)
            {
                var metodopago = await _contexto.MetodoPago!.ToListAsync();
                return metodopago;
            }
        }
    }
}