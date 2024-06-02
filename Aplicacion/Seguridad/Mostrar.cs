using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Aplicacion.ManejadorError;
using Dominio.entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Seguridad
{
    public class Mostrar
    {
        public class Ejecuta : IRequest<List<UsuarioData>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<UsuarioData>>
        {
            private readonly UserManager<Usuario> _usermanager;
            private readonly SignInManager<Usuario> _signInManager;
            public Manejador(UserManager<Usuario> usermanager, SignInManager<Usuario> signInManager)
            {
                _usermanager = usermanager;
                _signInManager = signInManager;
            }

            public async Task<List<UsuarioData>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                
                var usuariosList = await _usermanager.Users.ToListAsync(cancellationToken);

                
                var usuarioDataList = usuariosList.Select(user => new UsuarioData
                {
                    PhoneNumber = user.PhoneNumber,
                    Username = user.UserName,
                    Email = user.Email,
                    NombreCompleto = user.NombreCompleto
                }).ToList();

                return usuarioDataList;
            }
        }
    }
}