using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Ventas
{
    public class Registrarventa
    {
        public class Ejecuta : IRequest<string>
        {
            public DateTime? Fecha{get; set; }
            public decimal? PrecioTotal{ get; set;}
            public string? Descripcion{ get; set; }
            public Guid ClienteId{ get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _ventaid = Guid.NewGuid();
                var venta = new Venta{
                    VentaId = _ventaid,
                    Fecha = DateTime.UtcNow,
                    PrecioTotal = request.PrecioTotal,
                    Descripcion = request.Descripcion,
                    ClienteId = request.ClienteId
                };
                _contexto.Venta!.Add(venta);

                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return "la creación fue exitosa";
                }
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo insertar el registro" });  
            }
        }

    }
}