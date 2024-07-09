using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Ventas
{
    public class VentaFiltrada
    {
        public Guid VentaId{ get; set; }
        public DateTime? Fecha{get; set; }
        public decimal? PrecioTotal{ get; set;}
        public string? Descripcion{ get; set; }
        public Guid? ClienteId{ get; set; }
        public String? Nombrecliente{ get; set; }
        public string? NombreProducto{ get; set; }
    }
}