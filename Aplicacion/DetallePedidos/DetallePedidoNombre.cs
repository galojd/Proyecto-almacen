using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.DetallePedidos
{
    public class DetallePedidoNombre
    {
        public Guid DetallePedidoId{ get; set; }
        public int? Cantidad{ get; set; }
        public Guid? ProductoId{ get; set; }
        public string? NombreProducto{ get; set; }
    }
}