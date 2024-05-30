using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ProductosProveedores
{
    public class EditaProductoProveedor
    {
        
        public class Ejecuta : IRequest
        {
            public Guid Id{ get; set; }
            public decimal? Preciocompra{ get; set; }
            public decimal? Preciounitario{ get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var productoproveedor = await _contexto.ProductoProveedor!.FindAsync(request.Id);
                if(productoproveedor == null){
                    throw new Exception("No se puede encontrar el registro");
                }
                productoproveedor.Preciocompra = request.Preciocompra ?? productoproveedor.Preciocompra;
                productoproveedor.Preciounitario = request.Preciounitario ?? productoproveedor.Preciounitario;
                
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