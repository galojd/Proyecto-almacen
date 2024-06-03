using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.DetallePedidos
{
    public class SeedDetallePedido
    {
        public class Insertadetallepedido : IRequest<Unit> { }

        public class Manejador : IRequestHandler<Insertadetallepedido, Unit>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Insertadetallepedido request, CancellationToken cancellationToken)
            {
                var random = new Random();
                var ventas = await _contexto.Venta!.ToListAsync();
                var productos = await _contexto.Producto!.ToListAsync();


                for (int i = 0; i < 50; i++)
                {
                    var producto = productos[random.Next(productos.Count)]; // Seleccionar una categoría aleatoria de la lista
                    var venta = ventas[random.Next(ventas.Count)]; // Seleccionar una categoría aleatoria de la lista

                    var detallepedido = new DetallePedido
                    {
                        Cantidad = random.Next(1, 15), // Generar un precio aleatorio
                        Precio = (decimal)random.NextDouble() * 100,// Generar un stock mínimo aleatorio
                        FechaPedido = DateTime.UtcNow,                        
                        ProductoId = producto.ProductoId, // Generar un precio aleatorio
                        VentaId = venta.VentaId  // Asignar el ID de la categoría aleatoria
                    };

                    _contexto.DetallePedido!.Add(detallepedido);
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