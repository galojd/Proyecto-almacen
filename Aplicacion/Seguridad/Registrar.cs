using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System.Net;
using Aplicacion.ManejadorError;
using Dominio.entities;
using Microsoft.AspNetCore.Identity;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Seguridad
{
    public class Registrar
    {
        //el irequest usuariodata indica lo que devolvera
        public class Ejecuta : IRequest<UsuarioData>
        {
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            public string? UserName {get;set;}
            public string? Telefono {get;set;}
        }

        public class manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly AlmacenOnlineContext _contexto;
            private readonly UserManager<Usuario> _usermanager;
            private readonly SignInManager<Usuario> _signInManager;
            public manejador(UserManager<Usuario> usermanager, SignInManager<Usuario> signInManager, AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
                _usermanager = usermanager;
                _signInManager = signInManager;
            }

            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //desde aho busco Users que a nivel de entidad representa la talla de users de la base de datos
                //Con Where realizo una consulta donde comparo el email de la tabla con el que esto ingresando, ne devolvera un valor boolean 
                var existe = await _contexto.Users.Where(x => x.Email == request.Email).AnyAsync();
                if(existe){
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new {mensaje = "El Email ya esta en uso"});
                }

                //evaluo la existencia del username
                var existeUserName = await _contexto.Users.Where(x => x.UserName == request.UserName).AnyAsync();
                if(existeUserName){
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new {mensaje = "El usuario ya se registro anteriormente"});
                }

                var usuario = new Usuario{
                    NombreCompleto = request.Nombre + " " + request.Apellido,
                    Email = request.Email,
                    UserName = request.UserName,
                    PhoneNumber = request.Telefono
                };

                var resultado = await _usermanager.CreateAsync(usuario, request.Password!);
                
                if(resultado.Succeeded){
                    return new UsuarioData{
                        NombreCompleto = usuario.NombreCompleto,
                        Username = usuario.UserName,
                        Email = usuario.Email,
                        PhoneNumber = usuario.PhoneNumber
                    };
                }
                throw new Exception("No se pudo agregar el nuevo usuario");
            }
        }


    }
}