using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Inventarios
{
    public class ProductoDTO
    {
        public Guid ProductoId{get;set;}     
        public string? Nombre{get;set;}
        public string? Descripcion{get;set;}
        public decimal? PrecioUnitario{get;set;}
        public DateTime? FechaActualizacion{get;set;}
        public Guid? CategoriaId{get;set;}
        public DateTime? FechaCreacion{get;set;}
        public int? StockMinimo{get;set;}
    }
}