using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Seguridad;
using Dominio.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    
    public class UsuarioController : Micontrollerbase
    {
        // http://localhost:5235/api/Usuario/login
        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login(Login.Ejecuta parametros){
            return await Mediator.Send(parametros);

        }
        
    }
}