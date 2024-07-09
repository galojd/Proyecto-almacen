using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistencia.seeders
{
    public class SeedMetodoPago : IEntityTypeConfiguration<MetodoPago>
    {
        public void Configure(EntityTypeBuilder<MetodoPago> builder)
    {
        builder.HasData(
            new MetodoPago { MetodoPagoId = Guid.NewGuid(), TipoMetodo = "efectivo" },
            new MetodoPago { MetodoPagoId = Guid.NewGuid(), TipoMetodo = "Visa" },
            new MetodoPago { MetodoPagoId = Guid.NewGuid(), TipoMetodo = "MasterCard" },
            new MetodoPago { MetodoPagoId = Guid.NewGuid(), TipoMetodo = "American Express" },
            new MetodoPago { MetodoPagoId = Guid.NewGuid(), TipoMetodo = "PayPal" }
        );
    }
    }
}