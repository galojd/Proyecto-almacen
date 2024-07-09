using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Aplicacion.Inventarios;

namespace Aplicacion.Ventas
{
    public class VentaDto
    {
        public Guid VentaId{ get; set; }
        public DateTime? Fecha{get; set; }
        public decimal? PrecioTotal{ get; set;}
        public string? Descripcion{ get; set; }
        public Guid? ClienteId{ get; set; }
        public ICollection<ProductoDTO> Productos{get;set;}
    }
}