using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Inventarios
{
    public class RegistrarInventario
    {
        public class Ejecuta : IRequest
        {
            public DateTime? FechaEntrada{ get; set; }
            public int? CantidadProducto{ get; set; }
            public Guid? ProveedorId{ get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _inventarioid = Guid.NewGuid();
                var inventario = new Inventario{
                    InventarioId = _inventarioid,
                    FechaEntrada = request.FechaEntrada,
                    CantidadProducto = request.CantidadProducto,
                    ProveedorId = request.ProveedorId
                };
                _contexto.Inventario!.Add(inventario);
                
                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el registro");
            }
        }
    }
}