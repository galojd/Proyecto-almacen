using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Productos
{
    public class SeedProducto
    {
        public class InsertaProductos : IRequest<Unit> { }

        public class Manejador : IRequestHandler<InsertaProductos, Unit>
        {
            private readonly AlmacenOnlineContext _contexto;

            public Manejador(AlmacenOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(InsertaProductos request, CancellationToken cancellationToken)
            {
                var random = new Random();
                var categorias = await _contexto.Categoria!.ToListAsync();
                var nombresGenerados = new HashSet<string>(); // Para asegurar que los nombres sean únicos


                for (int i = 0; i < 50; i++)
                {

                    string nombreProducto;
                    do
                    {
                        nombreProducto = GenerarNombreProducto(random);
                    } while (nombresGenerados.Contains(nombreProducto));

                    nombresGenerados.Add(nombreProducto);

                    var categoria = categorias[random.Next(categorias.Count)]; // Seleccionar una categoría aleatoria de la lista

                    var producto = new Producto
                    {
                        Nombre = nombreProducto,
                        Descripcion = "Este es un producto en perfecto estado",
                        PrecioUnitario = (decimal)random.NextDouble() * 100, // Generar un precio aleatorio
                        FechaCreacion = DateTime.UtcNow,
                        StockMinimo = random.Next(1, 100), // Generar un stock mínimo aleatorio
                        CategoriaId = categoria.CategoriaId // Asignar el ID de la categoría aleatoria
                    };

                    _contexto.Producto!.Add(producto);
                }

                var valor = await _contexto.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar los registros");

            }

            private string GenerarNombreProducto(Random random)
            {
                var nombres = new[]
                {
                "RX", "GTX", "RTX", "Placa Madre", "SSD", "HDD", "RAM", "CPU", "GPU", "Fuente", "Monitor", "Teclado", "Mouse"
            };
                var descripciones = new[]
                {
                "6800", "3080", "970", "AM4", "Intel i7", "Ryzen 5", "DDR4", "1TB", "500GB", "750W", "144Hz", "Mecánico", "Óptico"
            };
                var modelos = new[]
                {
                "Pro", "Ultra", "Plus", "Max", "Gaming", "Master", "Elite", "Extreme", "Prime", "Advanced", "Expert", "Turbo"
            };

                return $"{nombres[random.Next(nombres.Length)]} {descripciones[random.Next(descripciones.Length)]} {modelos[random.Next(modelos.Length)]}";
            }
        }
    }
}
