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
            private readonly Random _random = new Random();

            private readonly string[] nombres = { "TechNova Solutions", "GreenLeaf Industries", "BlueWave Technologies", "CrystalClear Innovations", "Sunrise Ventures", "PrimeSphere Enterprises", "EcoFusion Dynamics", "Apex Global Services", "Evergreen Holdings", "DynamicEdge Software" };
            private readonly string[] contactos = { "Pedro", "Pablo", "Manuel", "Alejandro", "Beatriz", "Carlos", "Daniela", "Eduardo", "Fernanda", "Gabriel" };
            private readonly string[] direcciones = { "Direccion1", "Direccion2", "Direccion3", "Direccion4", "Direccion5", "Direccion6", "Direccion7", "Direccion8", "Direccion9", "Direccion10" };

            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(InsertaProveedores request, CancellationToken cancellationToken)
            {
                //var random = new Random();
                var productoproveedor = await _contexto.ProductoProveedor!.ToListAsync();

                for (int i = 0; i < 50; i++)
                {
                    var prodpro = productoproveedor[_random.Next(productoproveedor.Count)]; // Seleccionar una categoría aleatoria de la lista
                    
                    var proveedor = new Proveedor
                    {
                        Nombre = "empresa" + i,
                        Contacto = contactos[_random.Next(contactos.Length)], // Generar un precio aleatorio
                        Telefono = "9" + _random.Next(100000000, 999999999).ToString(),
                        Direccion = direcciones[_random.Next(direcciones.Length)], // Generar un stock mínimo aleatorio
                        Email = $"email{_random.Next(1, 100)}@gmail.com",
                        RUC = $"{_random.Next(100000000, 999999999)}{_random.Next(0, 9)}",
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