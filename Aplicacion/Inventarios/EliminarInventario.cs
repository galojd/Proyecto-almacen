using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.Inventarios
{
    public class EliminarInventario
    {
        public class Ejecuta: IRequest{
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                
                var detalleinventarioDB = _contexto.DetalleInventario!.Where(x => x.InventarioId == request.Id);
                foreach(var detalleinventario in detalleinventarioDB){
                    _contexto.DetalleInventario!.Remove(detalleinventario);
                }

                var inventarioproDB = _contexto.InventarioProducto!.Where(x => x.InventarioId == request.Id);
                foreach(var inventariopro in inventarioproDB){
                    _contexto.InventarioProducto!.Remove(inventariopro);
                }

                var inventario = await _contexto.Inventario!.FindAsync(request.Id);
                if(inventario == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                _contexto.Remove(inventario);
                
                var resultado = await _contexto.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                } 
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo eliminar el registro" });  
            }
        }
    }
}