using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.entities
{
    public class Inventario
    {
        public Guid InventarioId{ get; set; }
        //public String? NombreInventario{ get; set; }
        public DateTime? FechaEntrada{ get; set; }
        public int? CantidadProducto{ get; set; }
        public Guid? ProveedorId{ get; set; }
        public Proveedor? Proveedor{ get; set; }
        public ICollection<DetalleInventario>? DetalleInventariolista{get;set;}
        public ICollection<InventarioProducto>? InventarioProductolista{get;set;}

    }
}