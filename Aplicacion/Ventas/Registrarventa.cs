using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Ventas
{
    public class Registrarventa
    {
        public class Ejecuta : IRequest
        {
            public DateTime? Fecha{get; set; }
            public decimal? PrecioTotal{ get; set;}
            public string? Descripcion{ get; set; }
            public Guid ClienteId{ get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
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
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar la venta");
            }
        }

    }
}