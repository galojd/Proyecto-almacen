using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Categorias
{
    public class RegistrarCategoria
    {
        public class Ejecuta : IRequest
        {
            public string? NombreCategoria { get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _categoriaid = Guid.NewGuid();
                var categoria = new Categoria{
                    CategoriaId = _categoriaid,
                    NombreCategoria = request.NombreCategoria
                };
                _contexto.Categoria!.Add(categoria);
                
                var valor = await _contexto.SaveChangesAsync();
                if(valor>0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el registro");
            }
        }
    }
}