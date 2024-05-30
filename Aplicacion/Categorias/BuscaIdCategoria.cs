using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.entities;
using MediatR;
using Persistencia;


namespace Aplicacion.Categorias
{
    public class BuscaIdCategoria
    {
        public class Ejecuta: IRequest<Categoria>{
            public Guid Id{get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta, Categoria>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<Categoria> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var categoria = await _contexto.Categoria!.FindAsync(request.Id);
                if(categoria == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                }
                return categoria;
            }
        }
    }
}