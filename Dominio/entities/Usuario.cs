using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Net.Http.Headers;

namespace Dominio.entities
{
    public class Usuario : IdentityUser
    {
   
        public string? NombreCompleto{get;set;}
                
    }
}