using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad
{
    public class Login
    {
        public class Ejecuta : IRequest<UsuarioData>
        {
            public string? Email { get; set; }
            public string? Password { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly UserManager<Usuario> _usermanager;
            private readonly SignInManager<Usuario> _signInManager;
            public Manejador(UserManager<Usuario> usermanager, SignInManager<Usuario> signInManager)
            {
                _usermanager = usermanager;
                _signInManager = signInManager;
            }

            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _usermanager.FindByEmailAsync(request.Email!);
                if (usuario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.Unauthorized, new {mensaje = "No se encontro el Email"});
                }
                
                var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password!, false);
                if (resultado.Succeeded){
                    return new UsuarioData {
                        NombreCompleto = usuario.NombreCompleto,
                        Email = usuario.Email,
                        Username = usuario.UserName
                    };
                }
                throw new ManejadorExcepcion(HttpStatusCode.Unauthorized);
            }
        }
    }
}