using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Devoluciones
{
    public class SeederDevolucion
    {
        public class Insertadevolucion : IRequest<Unit> { }

        public class Manejador : IRequestHandler<Insertadevolucion, Unit>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Insertadevolucion request, CancellationToken cancellationToken)
            {
                var random = new Random();
                var DetallePedidos = await _contexto.DetallePedido!.ToListAsync();

                for (int i = 0; i < 50; i++)
                {
                    var DetallePedido = DetallePedidos[random.Next(DetallePedidos.Count)]; // Seleccionar una categoría aleatoria de la lista

                    var devolucion = new Devolucion
                    {
                        Cantidad = random.Next(1, 10),
                        FechaDevolucion = DateTime.UtcNow,
                        Descripcion = "Descripcion generica",
                        DetallePedidoId = DetallePedido.DetallePedidoId
                    };

                    _contexto.Devolucion!.Add(devolucion);
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