using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.ProductosProveedores
{
    public class RegistraProductoProveedor
    {
        public class Ejecuta : IRequest<string>
        {
            public decimal? Preciocompra{ get; set; }
            public decimal? Preciounitario{ get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _productoproveedorid = Guid.NewGuid();
                var productoproveedor = new ProductoProveedor{
                    ProductoProveedorId = _productoproveedorid,
                    Preciocompra = request.Preciocompra,
                    Preciounitario = request.Preciounitario                    
                };
                _contexto.ProductoProveedor!.Add(productoproveedor);
                
                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return "la creación fue exitosa";
                }
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo insertar el registro" });  
            }
        }
    }
}