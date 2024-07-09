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
    public class SeedInventario
    {
        public class InsertaInventario : IRequest<Unit> { }

        public class Manejador : IRequestHandler<InsertaInventario, Unit>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(InsertaInventario request, CancellationToken cancellationToken)
            {
                var random = new Random();
                var proveedores = await _contexto.Proveedor!.ToListAsync();

                    for (int i = 0; i < 50; i++)
                    {
                        var proveedor = proveedores[random.Next(proveedores.Count)]; // Seleccionar una categoría aleatoria de la lista

                        var inventario = new Inventario
                        {
                            CantidadProducto = random.Next(1, 500), // Generar un precio aleatorio
                            FechaEntrada = DateTime.UtcNow,// Generar un stock mínimo aleatorio
                            ProveedorId = proveedor.ProveedorId // Asignar el ID de la categoría aleatoria
                        };

                        _contexto.Inventario!.Add(inventario);
                    }

                    var valor = await _contexto.SaveChangesAsync();
                    if (valor > 0)
                    {
                        return Unit.Value;
                    }
                    throw new Exception("No se pudo insertar los registros");
            }
        }


    }
}