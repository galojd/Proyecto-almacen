using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Devoluciones
{
    public class ConsultaDevolucion
    {
        
        public class Listadevolucion : IRequest<List<Devolucion>>{}

        public class Manejador : IRequestHandler<Listadevolucion, List<Devolucion>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<List<Devolucion>> Handle(Listadevolucion request, CancellationToken cancellationToken)
            {
                var devolucion = await _contexto.Devolucion!.ToListAsync();
                return devolucion;
            }
        }
    }
}