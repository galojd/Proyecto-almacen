using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.PreciosWeb
{
    public class RegistrarPrecioweb
    {
        public class Ejecuta : IRequest
        {
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
                Guid _preciowebid = Guid.NewGuid();
                var precioweb = new PrecioWeb{
                    PrecioWebId = _preciowebid,
                    Url = request.Url                    
                };
                _contexto.PrecioWeb!.Add(precioweb);
                
                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el registro");
            }
        }

    }
}