using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Inventarios
{
    public class DetalleInventarioDTO
    {
        public Guid DetalleInventarioId{ get; set; }
        public int? StockAnterior{ get; set; }
        public int? StockIngreso{ get; set; }
        public int? StockTotal{ get; set; }
        public string? Descripcion{ get; set; }
        public decimal? Precio{get;set;}
        public Guid? ProductoId{ get; set; }
        public Guid? InventarioId{get; set; }
    }
}