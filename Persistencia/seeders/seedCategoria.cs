using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Dominio.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.seeders
{
    public class seedCategoria : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasData(
            new Categoria { CategoriaId = Guid.NewGuid(), NombreCategoria = "Placa madre" },
            new Categoria { CategoriaId = Guid.NewGuid(), NombreCategoria = "Tarjeta gráfica" },
            new Categoria { CategoriaId = Guid.NewGuid(), NombreCategoria = "Fuente de alimentación" },
            new Categoria { CategoriaId = Guid.NewGuid(), NombreCategoria = "Memoria RAM" },
            new Categoria { CategoriaId = Guid.NewGuid(), NombreCategoria = "Disco duro SSD" },
            new Categoria { CategoriaId = Guid.NewGuid(), NombreCategoria = "Procesador" }
        );
        }
    }
}