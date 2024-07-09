using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Inventarios
{
    public class RegistrarInventario
    {
        public class Ejecuta : IRequest<string>
        {
            public DateTime? FechaEntrada{ get; set; }
            public int? CantidadProducto{ get; set; }
            public Guid? ProveedorId{ get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
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
                    return "la creación fue exitosa";
                }
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo insertar el registro" });  
            }
        }
    }
}