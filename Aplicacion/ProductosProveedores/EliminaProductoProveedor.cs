using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ProductosProveedores
{
    public class EliminaProductoProveedor
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
                
                var inventarioproductoDB = _contexto.InventarioProducto!.Where(x => x.ProductoProveedorId == request.Id);
                foreach(var inventarioproducto in inventarioproductoDB){
                    _contexto.InventarioProducto!.Remove(inventarioproducto);
                }

                var proveedorDB = _contexto.Proveedor!.Where(x => x.ProductoProveedorId == request.Id);
                foreach(var proveedor in proveedorDB){
                    _contexto.Proveedor!.Remove(proveedor);
                }

                var productoproveedor = await _contexto.ProductoProveedor!.FindAsync(request.Id);
                if(productoproveedor == null){
                    throw new Exception("El registro no existe");
                }
                _contexto.Remove(productoproveedor);
                
                var resultado = await _contexto.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                } 
                throw new Exception("No se pudo eliminar el registro");
            }
        }
    }
}