using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Proveedores
{
    public class BuscaIdProveedor
    {
        public class Ejecuta: IRequest<Proveedor>{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, Proveedor>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Proveedor> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var proveedor = await _contexto.Proveedor!.FindAsync(request.Id);
                if(proveedor == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                return proveedor;
            }
        }
    }
}