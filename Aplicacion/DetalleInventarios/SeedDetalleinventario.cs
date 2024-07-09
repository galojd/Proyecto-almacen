using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.DetalleInventarios
{
    public class SeedDetalleinventario
    {
        public class InsertadetalleInventario : IRequest<Unit> { }

        public class Manejador : IRequestHandler<InsertadetalleInventario, Unit>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(InsertadetalleInventario request, CancellationToken cancellationToken)
            {
                var random = new Random();
                var productos = await _contexto.Producto!.ToListAsync();
                var inventarios = await _contexto.Inventario!.ToListAsync();

                var stockAnterior = random.Next(1, 500);
                var stockIngreso = random.Next(1, 500);

                for (int i = 0; i < 50; i++)
                {
                    var producto = productos[random.Next(productos.Count)]; // Seleccionar una categoría aleatoria de la lista
                    var inventario = inventarios[random.Next(inventarios.Count)]; // Seleccionar una categoría aleatoria de la lista

                    var detalleinventario = new DetalleInventario
                    {
                        StockAnterior = stockAnterior, // Generar un precio aleatorio
                        StockIngreso = stockIngreso,// Generar un stock mínimo aleatorio
                        StockTotal = stockAnterior + stockIngreso,
                        Descripcion = "Descripcion generica", // Generar un precio aleatorio
                        Precio = (decimal)random.NextDouble() * 100,// Generar un stock mínimo aleatorio
                        ProductoId = producto.ProductoId, // Generar un precio aleatorio
                        InventarioId = inventario.InventarioId  // Asignar el ID de la categoría aleatoria
                    };

                    _contexto.DetalleInventario!.Add(detalleinventario);
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