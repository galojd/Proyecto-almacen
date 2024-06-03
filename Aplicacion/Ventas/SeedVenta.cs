using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Ventas
{
    public class SeedVenta
    {
        public class InsertaVenta : IRequest<Unit> { }

        public class Manejador : IRequestHandler<InsertaVenta, Unit>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(InsertaVenta request, CancellationToken cancellationToken)
            {
                var random = new Random();
                var clientes = await _contexto.Cliente!.ToListAsync();

                for (int i = 0; i < 50; i++)
                    {
                        var cliente = clientes[random.Next(clientes.Count)]; // Seleccionar una categoría aleatoria de la lista

                        var venta = new Venta
                        {
                            Fecha = DateTime.UtcNow,
                            PrecioTotal = (decimal)random.NextDouble() * 100,
                            Descripcion = "Descripcion generica",
                            ClienteId = cliente.ClienteId
                        };

                        _contexto.Venta!.Add(venta);
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