using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.Ventas
{
    public class EditarVenta
    {
        public class Ejecuta : IRequest
        {
            public Guid Id{ get; set; }
            public DateTime? Fecha{get; set; }
            public decimal? PrecioTotal{ get; set;}
            public string? Descripcion{ get; set; }          
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var venta = await _contexto.Venta!.FindAsync(request.Id);
                if(venta == null){
                    throw new Exception("No se puede encontrar el registro");
                }

                venta.PrecioTotal = request.PrecioTotal ?? venta.PrecioTotal;
                venta.Descripcion = request.Descripcion ?? venta.Descripcion;
                venta.Fecha = DateTime.UtcNow;

                var resultado = await _contexto.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo modificar el registro");
            }
        }
    }
}