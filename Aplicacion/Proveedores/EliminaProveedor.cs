using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.Proveedores
{
    public class EliminaProveedor
    {
        public class Ejecuta: IRequest{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                
                var inventarioDB = _contexto.Inventario!.Where(x => x.ProveedorId == request.Id);
               
                foreach(var inventario in inventarioDB){
                    _contexto.Inventario!.Remove(inventario);
                }
                var proveedor = await _contexto.Proveedor!.FindAsync(request.Id);
                if(proveedor == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                _contexto.Remove(proveedor);
                
                var resultado = await _contexto.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                } 
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo eliminar el registro" });  
            }
        }
    }
}