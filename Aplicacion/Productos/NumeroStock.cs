using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Productos
{
    public class NumeroStock
    {
        public Guid ProductoId{get;set;}     
        public string? Nombre{get;set;}
        public int? StockTotal{ get; set; }
    }
}