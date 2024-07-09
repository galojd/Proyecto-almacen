using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.PreciosWeb
{
    public class ConsultaPrecioweb
    {
        public class Listaprecioweb : IRequest<List<PrecioWeb>>{}

        public class Manejador : IRequestHandler<Listaprecioweb, List<PrecioWeb>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<List<PrecioWeb>> Handle(Listaprecioweb request, CancellationToken cancellationToken)
            {
                var precioweb = await _contexto.PrecioWeb!.ToListAsync();
                return precioweb;
            }
        }
    }
}