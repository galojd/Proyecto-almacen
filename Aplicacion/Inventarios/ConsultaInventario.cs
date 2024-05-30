using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Inventarios
{
    public class ConsultaInventario
    {
        public class Listainventario : IRequest<List<Inventario>>{}

        public class Manejador : IRequestHandler<Listainventario, List<Inventario>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<List<Inventario>> Handle(Listainventario request, CancellationToken cancellationToken)
            {
                var inventario = await _contexto.Inventario!.ToListAsync();
                return inventario;
            }
        }
    }
}