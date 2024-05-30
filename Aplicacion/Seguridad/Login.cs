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
        public class Ejecuta : IRequest<Usuario>
        {
            public string? Email { get; set; }
            public string? Password { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta, Usuario>
        {
            private readonly UserManager<Usuario> _usermanager;
            private readonly SignInManager<Usuario> _signInManager;
            public Manejador(UserManager<Usuario> usermanager, SignInManager<Usuario> signInManager)
            {
                _usermanager = usermanager;
                _signInManager = signInManager;
            }

            public async Task<Usuario> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //se verifica que el usuario exista
                var usuario = await _usermanager.FindByEmailAsync(request.Email!);
                if (usuario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.Unauthorized, new {mensaje = "No se encontro el Email"});
                }
                
                var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password!, false);
                if (resultado.Succeeded){
                    return usuario;
                }
                throw new ManejadorExcepcion(HttpStatusCode.Unauthorized);
            }
        }
    }
}