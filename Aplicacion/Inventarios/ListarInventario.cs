using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Inventarios
{
    public class ListaInventario
    {
        public class Listainventario : IRequest<List<InventarioLimpio>>{}

        public class Manejador : IRequestHandler<Listainventario, List<InventarioLimpio>>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto){
               _contexto = contexto;
                
            }
            public async Task<List<InventarioLimpio>> Handle(Listainventario request, CancellationToken cancellationToken)
            {
                var inventario = await _contexto.Inventario!.ToListAsync(cancellationToken);
                
                var inventarioLimpioList = new List<InventarioLimpio>();  
                int contador = 1;
                foreach (var inv in inventario)
                {
                var inventarioLimpio = new InventarioLimpio
                {
                    Id = inv.InventarioId,
                    Nombreinventario = $"Inventario {contador}",
                };                                

                inventarioLimpioList.Add(inventarioLimpio);
                contador++;
                }
                 return inventarioLimpioList;
        }      
    }
    }
}