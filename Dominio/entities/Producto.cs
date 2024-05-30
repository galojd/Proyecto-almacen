using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.entities
{
    public class Producto
    {
        public Guid ProductoId{get;set;}     
        public string? Nombre{get;set;}
        public string? Descripcion{get;set;}

        [Column(TypeName = "decimal(18,4)")]
        public decimal? PrecioUnitario{get;set;}
        public DateTime? FechaActualizacion{get;set;}
        public DateTime? FechaCreacion{get;set;}
        public Guid? CategoriaId{get;set;}
        public Categoria? Categoria{get;set;}
        public ICollection<DetallePedido>? DetallePedidolista{get;set;}
        public ICollection<PrecioWebProducto>? PrecioWebProductolista{get;set;}
        public ICollection<DetalleInventario>? DetalleInventariolista{get;set;}       
    }
}