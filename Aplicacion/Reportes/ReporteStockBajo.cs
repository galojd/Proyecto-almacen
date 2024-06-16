using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Reportes
{
    public class ReporteStockBajo
    {
        public Guid Id { get; set; }
        public string? NombreProducto { get; set; }
        public string? Descripcion { get; set; }
        public int? StockMinimo{get;set;}
        public int? Stocktotal{get;set;}
        public string? Comentario{ get; set; }
        
    }
}