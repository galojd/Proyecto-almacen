using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Persistencia.seeders;

namespace Persistencia
{
    public class AlmacenOnlineContext : IdentityDbContext<Usuario> 
    {
        //este metodo se usa para posteriormente realizar las migraciones
        public AlmacenOnlineContext(DbContextOptions options) : base(options){
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //esto lo creo para las migraciones de tablas
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new seedCategoria());
            modelBuilder.ApplyConfiguration(new SeedMetodoPago());
            modelBuilder.ApplyConfiguration(new SeedCliente());
            modelBuilder.ApplyConfiguration(new SeedProductoProveedor());

             
        } 

        public DbSet<Categoria>? Categoria{get;set;}
        public DbSet<Cliente>? Cliente{get;set;}
        public DbSet<CompraPago>? CompraPago{get;set;}
        public DbSet<DatosEscaneo>? DatosEscaneo{get;set;}
        public DbSet<DetalleInventario>? DetalleInventario{get;set;}
        public DbSet<DetallePedido>? DetallePedido{get;set;}
        public DbSet<Devolucion>? Devolucion{get;set;}
        public DbSet<Inventario>? Inventario{get;set;}
        public DbSet<InventarioProducto>? InventarioProducto{get;set;}
        public DbSet<MetodoPago>? MetodoPago{get;set;}
        public DbSet<PrecioWeb>? PrecioWeb{get;set;}
        public DbSet<PrecioWebProducto>? PrecioWebProducto{get;set;}
        public DbSet<Producto>? Producto{get;set;}
        public DbSet<ProductoProveedor>? ProductoProveedor{get;set;}
        public DbSet<Proveedor>? Proveedor{get;set;}
        public DbSet<Venta>? Venta{get;set;}
    }
}