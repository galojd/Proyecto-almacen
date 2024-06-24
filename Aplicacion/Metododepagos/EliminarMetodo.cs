using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.Metododepagos
{
    public class EliminarMetodo
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
                var metodoDB = _contexto.CompraPago!.Where(x => x.MetodoPagoId == request.Id);
                //las elimino de cursoinstructor
                foreach(var devolucion in metodoDB){
                    _contexto.CompraPago!.Remove(devolucion);
                }

                var metodo = await _contexto.MetodoPago!.FindAsync(request.Id);
                if(metodo == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                _contexto.Remove(metodo);

                var resultado = await _contexto.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                } 
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo eliminar el registro" });
            }
        }
    }
}