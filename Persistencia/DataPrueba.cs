using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using Microsoft.AspNetCore.Identity;

namespace Persistencia
{
    public class DataPrueba
    {
        public static async Task InsertarData(AlmacenOnlineContext context, UserManager<Usuario> usuarioManager){
            //validamos que existe algun usuario 
            if(usuarioManager.Users.Any() == false){
                //se crea el objeto a insertar en la base de datos
                var usuario = new Usuario{NombreCompleto = "Bruno Dias", UserName = "Batman", Email = "Batman@gmail.com", PhoneNumber = "986100510"};
                await usuarioManager.CreateAsync(usuario, "Baticontraseña123#");
            }

        }
    }
}