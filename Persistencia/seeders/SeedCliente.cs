using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistencia.seeders
{
    public class SeedCliente : IEntityTypeConfiguration<Cliente>
    {

        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            var random = new Random();

            var clientes = Enumerable.Range(1, 50).Select(i => new Cliente
            {
                ClienteId = Guid.NewGuid(),
                DNI = GenerarDNI(random),
                RUC = "20428729201",
                Nombres = GenerarNombres(random),
                Telefono = GenerarTelefono(random),
                Email = GenerarEmail(random),
                Direccion = GenerarDireccion(random),
                Fecharegistro = DateTime.UtcNow
            }).ToArray();

            builder.HasData(clientes);
        }

        // Método para generar un DNI aleatorio
        private string GenerarDNI(Random? random)
        {
            return random.Next(10000000, 99999999).ToString();
        }

        

        // Método para generar nombres aleatorios
        private string GenerarNombres(Random? random)
        {
            var nombres = new[] { "Juan", "María", "Luis", "Ana", "Pedro", "Laura", "Diego", "Sofía", "Carlos", "Lucía" };
            return nombres[random.Next(nombres.Length)] + " " + nombres[random.Next(nombres.Length)];
        }

        // Método para generar un teléfono aleatorio
        private string GenerarTelefono(Random? random)
        {
            return random.Next(100000000, 999999999).ToString();
        }

        // Método para generar un email aleatorio
        private string GenerarEmail(Random? random)
        {
            var nombres = new[] { "cliente", "usuario", "comprador", "contacto", "correo" };
            var dominios = new[] { "gmail.com", "hotmail.com", "yahoo.com", "outlook.com", "example.com" };
            return $"{nombres[random.Next(nombres.Length)]}{random.Next(1000)}@{dominios[random.Next(dominios.Length)]}";
        }

        // Método para generar una dirección aleatoria
        private string GenerarDireccion(Random? random)
        {
            var calles = new[] { "Calle A", "Calle B", "Calle C", "Calle D", "Calle E" };
            var ciudades = new[] { "Lima", "Arequipa", "Trujillo", "Cusco", "Piura" };
            return $"{calles[random.Next(calles.Length)]}, {random.Next(1, 100)}, {ciudades[random.Next(ciudades.Length)]}";
        }


    }
}