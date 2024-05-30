using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Categorias
{
    public class ConsultaCategoria
    {
        public class Listacategoria : IRequest<List<Categoria>>{}

        public class Manejador : IRequestHandler<Listacategoria, List<Categoria>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }

            public async Task<List<Categoria>> Handle(Listacategoria request, CancellationToken cancellationToken)
            {
                var categoria = await _contexto.Categoria!.ToListAsync();
                return categoria;
            }
        }
        
    }
}