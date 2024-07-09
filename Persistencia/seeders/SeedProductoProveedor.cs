using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistencia.seeders
{
    public class SeedProductoProveedor : IEntityTypeConfiguration<ProductoProveedor>
    {
        public void Configure(EntityTypeBuilder<ProductoProveedor> builder)
        {
            var random = new Random();

            var productoproveedor = Enumerable.Range(1, 50).Select(i => new ProductoProveedor
            {
                ProductoProveedorId = Guid.NewGuid(),
                Preciocompra = Math.Round((decimal)(random.NextDouble() * 1000), 2),
                Preciounitario = Math.Round((decimal)(random.NextDouble() * 1000), 2)
            }).ToArray();

            builder.HasData(productoproveedor);
        }
    }
}