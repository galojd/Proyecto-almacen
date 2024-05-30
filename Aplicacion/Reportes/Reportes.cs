using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Aplicacion.Reportes
{
    public class Reportes 
    {
        public Guid Id{ get; set; }
        public string? NombreProducto{ get; set; }
        public string? Descripcion{ get; set; }
        public int? Stocktotal{ get; set; }
        public decimal? Precio{ get; set; }
        public string? NombreProveedor{ get; set; }
        public DateTime? Fechaentrada{ get; set; }
        public int Cantidad{ get; set; }

        
    }
}