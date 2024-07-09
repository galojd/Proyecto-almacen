using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.entities
{
    public class ProductoProveedor
    {
        public Guid ProductoProveedorId{ get; set; }
        
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Preciocompra{ get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? Preciounitario{ get; set; }

        public ICollection<InventarioProducto>? InventarioProducto{get;set;}
        public ICollection<Proveedor>? Proveedorlista{get;set;}
    }
}//ya esta