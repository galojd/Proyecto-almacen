using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ProductosProveedores
{
    public class Consultaproductoproveedor
    {
        public class Listaproductoproveedor : IRequest<List<ProductoProveedor>>{}

        public class Manejador : IRequestHandler<Listaproductoproveedor, List<ProductoProveedor>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<List<ProductoProveedor>> Handle(Listaproductoproveedor request, CancellationToken cancellationToken)
            {
                var productoproveedor = await _contexto.ProductoProveedor!.ToListAsync();
                return productoproveedor;
        }
    }

    }
}