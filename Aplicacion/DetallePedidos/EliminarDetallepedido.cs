using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.DetallePedidos
{
    public class EliminarDetallepedido
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
                //primero busco los instructores ligados a Curso
                var devolucionDB = _contexto.Devolucion!.Where(x => x.DetallePedidoId == request.Id);
                //las elimino de cursoinstructor
                foreach(var devolucion in devolucionDB){
                    _contexto.Devolucion!.Remove(devolucion);
                }

                var detallepedido = await _contexto.DetallePedido!.FindAsync(request.Id);
                if(detallepedido == null){
                    throw new Exception("El registro no existe");
                }
                _contexto.Remove(detallepedido);
                
                var resultado = await _contexto.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                } 
                throw new Exception("No se pudo eliminar el registro");
            }
        }
    }
}