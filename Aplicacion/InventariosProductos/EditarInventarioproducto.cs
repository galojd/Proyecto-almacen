using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.InventariosProductos
{
    public class EditarInventarioproducto
    {
        public class Ejecuta : IRequest
        {
            public Guid Id{ get; set; }
            public DateTime? Fechaentrega{ get; set; }
            public decimal? Descuento{ get;set; }
            public int? Cantidad{ get;set;}
            public decimal? PrecioTotal{ get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var inventarioProducto = await _contexto.InventarioProducto!.FindAsync(request.Id);
                if(inventarioProducto == null){
                    throw new Exception("No se puede encontrar el registro");
                }
                inventarioProducto.Cantidad = request.Cantidad ?? inventarioProducto.Cantidad;
                inventarioProducto.Fechaentrega = request.Fechaentrega ?? inventarioProducto.Fechaentrega;
                inventarioProducto.Descuento = request.Descuento ?? inventarioProducto.Descuento;
                inventarioProducto.PrecioTotal = request.PrecioTotal ?? inventarioProducto.PrecioTotal;
                                
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