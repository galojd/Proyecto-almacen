using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.entities
{
    public class InventarioProducto
    {
        public Guid InventarioProductoId{ get; set; }
        public DateTime? Fechaentrega{ get; set; }
        
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Descuento{ get;set; }
        public int? Cantidad{ get;set;}

        [Column(TypeName = "decimal(18,4)")]
        public decimal? PrecioTotal{ get; set; }
        public Guid? InventarioId{ get; set; }
        public Guid? ProductoProveedorId{ get; set; }
        public Inventario? Inventario{get;set;} 
        public ProductoProveedor? ProductoProveedor{get;set;} 
        


    } //Ya esta
}