using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.DetalleInventarios
{
    public class EditaDetalleinventario
    {
        public class Ejecuta : IRequest
        {
            public Guid Id{ get; set; }
            public int? StockAnterior{ get; set; }
            public int? StockIngreso{ get; set; }
            public int? StockTotal{ get; set; }
            public string? Descripcion{ get; set; }
            public decimal? Precio{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
             private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var detalleinventario = await _contexto.DetalleInventario!.FindAsync(request.Id);
                if(detalleinventario == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "No se puede encontrar el registro" });
                }
                detalleinventario.StockAnterior = request.StockAnterior ?? detalleinventario.StockAnterior;
                detalleinventario.StockIngreso = request.StockIngreso ?? detalleinventario.StockIngreso;
                detalleinventario.StockTotal = request.StockTotal ?? detalleinventario.StockTotal;
                detalleinventario.Descripcion = request.Descripcion ?? detalleinventario.Descripcion;
                detalleinventario.Precio = request.Precio ?? detalleinventario.Precio;
                
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