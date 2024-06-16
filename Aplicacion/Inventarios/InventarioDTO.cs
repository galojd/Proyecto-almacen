using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Inventarios
{
    public class InventarioDTO
    {
        public Guid InventarioId{ get; set; }
        public DateTime? FechaEntrada{ get; set; }
        public int? CantidadProducto{ get; set; }
        public Guid? ProveedorId{ get; set; }
        public ICollection<ProductoDTO> Productos{get;set;}
    }
}