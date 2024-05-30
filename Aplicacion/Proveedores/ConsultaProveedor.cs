using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Proveedores
{
    public class ConsultaProveedor
    {
        public class Listaproveedor : IRequest<List<Proveedor>>{}

        public class Manejador : IRequestHandler<Listaproveedor, List<Proveedor>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<List<Proveedor>> Handle(Listaproveedor request, CancellationToken cancellationToken)
            {
                var proveedor = await _contexto.Proveedor!.ToListAsync();
                return proveedor;
            }
        }
    }
}