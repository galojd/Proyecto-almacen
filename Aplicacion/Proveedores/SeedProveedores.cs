using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Proveedores
{
    public class SeedProveedores
    {
        public class InsertaProveedores : IRequest<Unit> { }

        public class Manejador : IRequestHandler<InsertaProveedores, Unit>
        {

            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(InsertaProveedores request, CancellationToken cancellationToken)
            {
                var random = new Random();
                var productoproveedor = await _contexto.ProductoProveedor!.ToListAsync();

                for (int i = 0; i < 50; i++)
                    {
                        var prodpro = productoproveedor[random.Next(productoproveedor.Count)]; // Seleccionar una categoría aleatoria de la lista

                        var proveedor = new Proveedor
                        {
                            Nombre = "producto aleatorio",
                            Contacto = "contacto aleatorio", // Generar un precio aleatorio
                            Telefono = "987156478",
                            Direccion = "Lima", // Generar un stock mínimo aleatorio
                            Email = "emailgenerico@gmail.com",
                            RUC = "12345678965",
                            Fecharegistro = DateTime.UtcNow,
                            ProductoProveedorId = prodpro.ProductoProveedorId
                             // Asignar el ID de la categoría aleatoria
                        };

                        _contexto.Proveedor!.Add(proveedor);
                    }

                    var valor = await _contexto.SaveChangesAsync();
                    if (valor > 0)
                    {
                        return Unit.Value;
                    }


                throw new NotImplementedException();
            }
        }
    }
}