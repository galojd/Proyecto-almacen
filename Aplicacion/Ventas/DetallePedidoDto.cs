using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Inventarios;

namespace Aplicacion.Ventas
{
    public class DetallePedidoDto
    {
        public Guid DetallePedidoId{ get; set; }
        public int? Cantidad{ get; set; }
        public decimal? Precio{ get;set;}
        public Guid VentaId{ get; set; }
        public VentaDto? Venta{ get; set; }
        public DateTime? FechaPedido{ get; set; }
        public Guid? ProductoId{ get; set; }
        public ProductoDTO? Producto{ get; set; }
    }
}