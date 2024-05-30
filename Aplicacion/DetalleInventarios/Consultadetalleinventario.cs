using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.DetalleInventarios
{
    public class Consultadetalleinventario
    {
        public class Listadetalleinventario : IRequest<List<DetalleInventario>>{}

        public class Manejador : IRequestHandler<Listadetalleinventario, List<DetalleInventario>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<List<DetalleInventario>> Handle(Listadetalleinventario request, CancellationToken cancellationToken)
            {
                var detalleinventario = await _contexto.DetalleInventario!.ToListAsync();
                return detalleinventario;
            }
        }
    }
}