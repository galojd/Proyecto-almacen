using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;
using JsonException = Aplicacion.ManejadorError.JsonException;

namespace Aplicacion.Categorias
{
    public class RegistrarCategoria
    {
        public class Ejecuta : IRequest<string>
        {
            public string? NombreCategoria { get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _categoriaid = Guid.NewGuid();
                var categoria = new Categoria{
                    CategoriaId = _categoriaid,
                    NombreCategoria = request.NombreCategoria
                };
                _contexto.Categoria!.Add(categoria);
                
                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return "la creación fue exitosa";
                }
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo insertar el registro" });  
            }
        }
    }
}