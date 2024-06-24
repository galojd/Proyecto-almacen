using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Clientes
{
    public class RegistrarCliente
    {
        public class ejecuta : IRequest<string>
        {
            public string? DNI{get;set;}
            public string? RUC{get;set;}   
            public string? Nombres{get;set;}
            public string? Telefono{get;set;}
            public string? Email{get;set;}
            public string? Direccion{get;set;}
        }

        public class Manejador : IRequestHandler<ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<string> Handle(ejecuta request, CancellationToken cancellationToken)
            {
                 //aqui generamos el id con un guid, el guid crea un valor aleatorio
                Guid _clienteid = Guid.NewGuid();
                var cliente = new Cliente{
                    ClienteId = _clienteid,
                    DNI = request.DNI,
                    RUC = request.RUC,
                    Nombres = request.Nombres,
                    Telefono = request.Telefono,
                    Email = request.Email,
                    Direccion = request.Direccion,
                    Fecharegistro = DateTime.UtcNow
                };
                //Aqui le indico que se agregue el cliente al contexto
                _contexto.Cliente!.Add(cliente);

                //aqui hago el commit que es la confirmacion a la base de datos
                //este SaveChangesAsync devuelve el estado de la transaccion, si devuelve 0 fallo, si es 1 o superior si se hizo la transaccion
                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return "la creación fue exitosa";
                }
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo insertar el registro" });  
            }
        }


    }
}