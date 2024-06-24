using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.Devoluciones
{
    public class EditaDevolucion
    {
        public class Ejecuta : IRequest
        {
            public Guid Id{ get; set; }
            public int? Cantidad{get;set;}
            public DateTime? FechaDevolucion{get;set;}
            public string? Descripcion{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var devolucion = await _contexto.Devolucion!.FindAsync(request.Id);
                if(devolucion == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "No se puede encontrar el registro" });
                }
                devolucion.Cantidad = request.Cantidad ?? devolucion.Cantidad;
                devolucion.Descripcion = request.Descripcion ?? devolucion.Descripcion;
                devolucion.FechaDevolucion = DateTime.UtcNow;
                
                var resultado = await _contexto.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo editar el registro" }); 
            }
        }
    }
}