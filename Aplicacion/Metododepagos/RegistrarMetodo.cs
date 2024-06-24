using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Metododepagos
{
    public class RegistrarMetodo
    {
        public class Ejecuta : IRequest<string>
        {
           public string? TipoMetodo{ get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _metodopagoid = Guid.NewGuid();
                var metodopago = new MetodoPago{
                    MetodoPagoId = _metodopagoid,
                    TipoMetodo = request.TipoMetodo
                };
                _contexto.MetodoPago!.Add(metodopago);

                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return "la creación fue exitosa";
                }
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo insertar el registro" });  
            }
        }
    }
}