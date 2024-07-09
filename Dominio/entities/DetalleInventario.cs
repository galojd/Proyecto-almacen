using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.entities
{
    public class DetalleInventario
    {
        public Guid DetalleInventarioId{ get; set; }
        public int? StockAnterior{ get; set; }
        public int? StockIngreso{ get; set; }
        public int? StockTotal{ get; set; }
        public string? Descripcion{ get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? Precio{get;set;}
        public Guid? ProductoId{ get; set; }
        public Guid? InventarioId{get; set; }
        public Producto? Producto{ get; set; }
        public Inventario? Inventario{ get; set; }
    }
}//YA ESTA