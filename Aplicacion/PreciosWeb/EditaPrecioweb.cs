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
    public class EditaPrecioweb
    {
        public class Ejecuta : IRequest
        {
            public Guid Id{ get; set; }
            public string? Url{ get;set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var precioweb = await _contexto.PrecioWeb!.FindAsync(request.Id);
                if(precioweb == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "No se puede encontrar el registro" });
                }
                precioweb.Url = request.Url ?? precioweb.Url;
                
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