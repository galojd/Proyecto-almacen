using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.entities
{
    public class Venta
    {
        public Guid VentaId{ get; set; }
        public DateTime? Fecha{get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? PrecioTotal{ get; set;}
        public string? Descripcion{ get; set; }
        public Guid? ClienteId{ get; set; }
        public Cliente? Cliente{ get; set; }
        public ICollection<DetallePedido>? DetallePedidolista{get;set;}
    }
}

//YA ESTA