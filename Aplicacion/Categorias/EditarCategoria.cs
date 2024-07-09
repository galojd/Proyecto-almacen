using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;
using JsonException = Aplicacion.ManejadorError.JsonException;

namespace Aplicacion.Categorias
{
    public class EditarCategoria
    {
        public class Ejecuta : IRequest<string>
        {
            public Guid Id{ get; set; }
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
                var categoria = await _contexto.Categoria!.FindAsync(request.Id);
                if(categoria == null){
                    //throw new Exception("No se puede encontrar el registro");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "No se puede encontrar el registro" });
                }
                categoria.NombreCategoria = request.NombreCategoria ?? categoria.NombreCategoria;
                
                
                var resultado = await _contexto.SaveChangesAsync();
                if (resultado > 0)
                {
                    return "Se actualizo correctamente";
                }

                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se pudo editar el registro" });  
            }
        }



    }
}