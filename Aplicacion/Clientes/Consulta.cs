using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Clientes
{
    public class Consulta
    {
        public class ListaClientes : IRequest<List<Cliente>>{}

        public class Manejador : IRequestHandler<ListaClientes, List<Cliente>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<List<Cliente>> Handle(ListaClientes request, CancellationToken cancellationToken)
            {
                var clientes = await _contexto.Cliente!.ToListAsync();
                return clientes;
            }
        }
    }
}