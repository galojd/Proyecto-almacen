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

                    for (int i = 0; i < 50; i++)
                    {
                        var categoria = categorias[random.Next(categorias.Count)]; // Seleccionar una categoría aleatoria de la lista

                        var producto = new Producto
                        {
                            Nombre = "Nombre aleatorio",
                            Descripcion = "Descripción aleatoria",
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



            }
        }
    }
