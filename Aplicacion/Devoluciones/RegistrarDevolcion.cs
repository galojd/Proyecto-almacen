using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Devoluciones
{
    public class RegistrarDevolcion
    {
        public class Ejecuta : IRequest<string>
        {
            public int? Cantidad{get;set;}
            public DateTime? FechaDevolucion{get;set;}
            public string? Descripcion{get;set;}
            public Guid? DetallePedidoId{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _devolucionid = Guid.NewGuid();
                var devolucion = new Devolucion{
                    DevolucionId = _devolucionid,
                    Cantidad = request.Cantidad,
                    FechaDevolucion = request.FechaDevolucion,
                    Descripcion = request.Descripcion,
                    DetallePedidoId = request.DetallePedidoId
                };
                _contexto.Devolucion!.Add(devolucion);
                
                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return "la creación fue exitosa";
                }
                throw new Exception("No se pudo insertar el registro");
            }
        }
    }
}