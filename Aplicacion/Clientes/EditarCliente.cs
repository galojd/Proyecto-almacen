using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.Clientes
{
    public class EditarCliente
    {
        public class Ejecuta : IRequest
        {
            public Guid ClienteId{get;set;}
            public string? DNI{get;set;}
            public string? RUC{get;set;}   
            public string? Nombres{get;set;}
            public string? Telefono{get;set;}
            public string? Email{get;set;}
            public string? Direccion{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var cliente = await _contexto.Cliente!.FindAsync(request.ClienteId);
                if(cliente == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "No se puede encontrar el registro" });
                }

                cliente.DNI = request.DNI ?? cliente.DNI;
                cliente.RUC = request.RUC ?? cliente.RUC;
                cliente.Nombres = request.Nombres ?? cliente.Nombres;
                cliente.Telefono = request.Telefono ?? cliente.Telefono;
                cliente.Email = request.Email ?? cliente.Email;
                cliente.Direccion = request.Direccion ?? cliente.Direccion;

                var resultado = await _contexto.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo insertar el registro" });  
            }
        }
    }
}