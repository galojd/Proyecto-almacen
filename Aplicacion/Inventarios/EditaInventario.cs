using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.Inventarios
{
    public class EditaInventario
    {
        public class Ejecuta : IRequest
        {
            public Guid Id{ get; set; }
            public DateTime? FechaEntrada{ get; set; }
            public int? CantidadProducto{ get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var inventario = await _contexto.Inventario!.FindAsync(request.Id);
                if(inventario == null){
                    throw new Exception("No se puede encontrar el registro");
                }
                inventario.CantidadProducto = request.CantidadProducto ?? inventario.CantidadProducto;
                inventario.FechaEntrada = DateTime.UtcNow;
                
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