using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.PreciosWebProductos
{
    public class RegistrarwebProducto
    {
        public class Ejecuta : IRequest<string>
        {
            public decimal? AnteriorPrecio{get;set;}
            public decimal? NuevoPrecio{get;set;}
            public DateTime? Fecha{get;set;}
            public Guid? ProductoId{ get; set; }
            public Guid? PrecioWebId{ get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                 Guid _preciowebid = Guid.NewGuid();
                var precioweb = new PrecioWebProducto{
                    PrecioWebProductoId = _preciowebid,
                    AnteriorPrecio = request.AnteriorPrecio,
                    NuevoPrecio = request.NuevoPrecio,
                    Fecha = DateTime.UtcNow,
                    ProductoId = request.ProductoId,
                    PrecioWebId = request.PrecioWebId                    
                };
                _contexto.PrecioWebProducto!.Add(precioweb);
                
                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return "la creación fue exitosa";
                }
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo insertar el registro" });  
            }
        }
    }
}