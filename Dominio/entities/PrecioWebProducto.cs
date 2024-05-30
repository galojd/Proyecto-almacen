using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.entities
{
    public class PrecioWebProducto
    {
        public Guid PrecioWebProductoId{ get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? AnteriorPrecio{get;set;}

        [Column(TypeName = "decimal(18,4)")]
        public decimal? NuevoPrecio{get;set;}
        public DateTime? Fecha{get;set;}
        public Guid? ProductoId{ get; set; }
        public Guid? PrecioWebId{ get; set; }
        public Producto? Producto{get;set;}
        public PrecioWeb? PrecioWeb{get;set;}

    }//ya esta
}