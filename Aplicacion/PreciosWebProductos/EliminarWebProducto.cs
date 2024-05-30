using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.PreciosWebProductos
{
    public class EliminarWebProducto
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
                var precioweb = await _contexto.PrecioWebProducto!.FindAsync(request.Id);
                if(precioweb == null){
                    throw new Exception("El registro no existe");
                }
                _contexto.Remove(precioweb);
                
                var resultado = await _contexto.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                } 
                throw new Exception("No se pudo eliminar el registro");
            }
        }
    }
}