using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.entities
{
    public class DetallePedido
    {
        public Guid DetallePedidoId{ get; set; }
        public int? Cantidad{ get; set; }
        
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Precio{ get;set;}
        public Guid VentaId{ get; set; }
        public Venta? Venta{ get; set; }
        public DateTime? FechaPedido{ get; set; }
        public Guid? ProductoId{ get; set; }
        public Producto? Producto{ get; set; }
        public ICollection<Devolucion>? Devolucionlista{get;set;}
        //ya esta

    }
}