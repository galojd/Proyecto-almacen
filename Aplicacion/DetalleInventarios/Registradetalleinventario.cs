using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.DetalleInventarios
{
    public class Registradetalleinventario
    {
        public class Ejecuta : IRequest
        {
            public int? StockAnterior { get; set; }
            public int? StockIngreso { get; set; }
            public int? StockTotal
            {
                get
                {
                    if (StockAnterior == null || StockIngreso == null) return 0;
                    
                    return StockAnterior + StockIngreso;
                }
            }
            public string? Descripcion { get; set; }
            public decimal? Precio { get; set; }
            public Guid? ProductoId { get; set; }
            public Guid? InventarioId { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _detalleinventarioid = Guid.NewGuid();
                //var stocktotal = request.StockAnterior + request.StockIngreso;
                var detalleinventario = new DetalleInventario
                {
                    DetalleInventarioId = _detalleinventarioid,
                    StockAnterior = request.StockAnterior,
                    StockIngreso = request.StockIngreso,
                    Descripcion = request.Descripcion,
                    StockTotal = request.StockTotal,
                    Precio = request.Precio,
                    ProductoId = request.ProductoId,
                    InventarioId = request.InventarioId

                };
                _contexto.DetalleInventario!.Add(detalleinventario);

                var valor = await _contexto.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el registro");
            }
        }
    }
}