using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.Proveedores
{
    public class EditaProveedor
    {
        public class Ejecuta : IRequest
        {
            public Guid Id{ get; set; }
            public string? Nombre{get;set;}
            public string? Contacto{get;set;}
            public string? Telefono{get;set;}
            public string? Direccion{get;set;}
            public string? Email{get;set;}
            public string? RUC{get;set;}
            public DateTime? Fecharegistro{get;set;}
        }

         public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var proveedor = await _contexto.Proveedor!.FindAsync(request.Id);
                if(proveedor == null){
                    throw new Exception("No se puede encontrar el registro");
                }
                proveedor.Nombre = request.Nombre ?? proveedor.Nombre;
                proveedor.Contacto = request.Contacto ?? proveedor.Contacto;
                proveedor.Telefono = request.Telefono ?? proveedor.Telefono;
                proveedor.Direccion = request.Direccion ?? proveedor.Direccion;
                proveedor.Email = request.Email ?? proveedor.Email;
                proveedor.RUC = request.RUC ?? proveedor.RUC;
                proveedor.Fecharegistro = DateTime.UtcNow;
                
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