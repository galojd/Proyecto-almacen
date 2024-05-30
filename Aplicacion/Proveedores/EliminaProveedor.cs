using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                //primero busco los instructores ligados a Curso
                var inventarioDB = _contexto.Inventario!.Where(x => x.ProveedorId == request.Id);
                //las elimino de cursoinstructor
                foreach(var inventario in inventarioDB){
                    _contexto.Inventario!.Remove(inventario);
                }
                var proveedor = await _contexto.Proveedor!.FindAsync(request.Id);
                if(proveedor == null){
                    throw new Exception("El registro no existe");
                }
                _contexto.Remove(proveedor);
                
                var resultado = await _contexto.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                } 
                throw new Exception("No se pudo eliminar el registro");
            }
        }
    }
}