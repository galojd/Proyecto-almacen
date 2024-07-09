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
        public decimal? PrecioUnitario{ get; set; }
        public DateTime? FechaActualizacion{ get; set; }
        public string? Categoria{ get; set; }
        public decimal? PrecioTotal{ get; set; }
        public string? NombreProveedor{ get; set; }
        public DateTime? Fechaentrada{ get; set; }
        public string? DescripcionInventario{ get; set; }
        public int? Cantidad{ get; set; }
        public int? Devolucioncantidad{  get; set; }
        public DateTime? Fechadevolucion{ get; set; }
        public String? DescripcionDevolucion{ get; set;}


        
    }
}