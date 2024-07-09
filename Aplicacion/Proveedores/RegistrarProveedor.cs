using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Proveedores
{
    public class RegistrarProveedor
    {
        public class Ejecuta : IRequest<string>
        {
            public string? Nombre{get;set;}
            public string? Contacto{get;set;}
            public string? Telefono{get;set;}
            public string? Direccion{get;set;}
            public string? Email{get;set;}
            public string? RUC{get;set;}
            public DateTime? Fecharegistro{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;
            private readonly Random _random;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
                 _random = new Random();
                
            }

            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var proveedorregistrado = await _contexto.Proveedor!
                                            .FirstOrDefaultAsync(p => p.Nombre == request.Nombre, cancellationToken);

                if (proveedorregistrado != null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.Conflict, new { mensaje = "Ya registro a este proveedor." }); 
                }
                var productoproveedor = await _contexto.ProductoProveedor!.ToListAsync();
                
                int randomIndex = _random.Next(productoproveedor.Count); 
                
                Guid randomProductoProveedorId = productoproveedor[randomIndex].ProductoProveedorId;

                Guid _proveedorid = Guid.NewGuid();
                var proveedor = new Proveedor{
                    ProveedorId = _proveedorid,
                    Nombre = request.Nombre,
                    Contacto = request.Contacto,
                    Telefono = request.Telefono,
                    Direccion = request.Direccion,
                    Email = request.Email,
                    RUC = request.RUC,
                    Fecharegistro = DateTime.UtcNow,
                    ProductoProveedorId = randomProductoProveedorId
                };
                _contexto.Proveedor!.Add(proveedor);
                
                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return "la creación fue exitosa";
                }
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo insertar el registro" });  
            }
        }
    }
}