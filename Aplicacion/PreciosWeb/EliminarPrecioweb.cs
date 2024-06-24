using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.PreciosWeb
{
    public class EliminarPrecioweb
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
                var instructoresDB = _contexto.PrecioWebProducto!.Where(x => x.PrecioWebId == request.Id);
                //las elimino de cursoinstructor
                foreach(var instructor in instructoresDB){
                    _contexto.PrecioWebProducto!.Remove(instructor);
                }
                
                var precioweb = await _contexto.PrecioWeb!.FindAsync(request.Id);
                if(precioweb == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                _contexto.Remove(precioweb);
                
                var resultado = await _contexto.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                } 
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo eliminar el registro" }); 
            }
        }
    }
}