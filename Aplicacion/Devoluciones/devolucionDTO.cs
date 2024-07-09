using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Inventarios;

namespace Aplicacion.Devoluciones
{
    public class devolucionDTO
    {
        public Guid DevolucionId{get;set;}
        public int? Cantidad{get;set;}
        public DateTime? FechaDevolucion{get;set;}
        public string? Descripcion{get;set;}
        public Guid? DetallePedidoId{get;set;}
        public string? productodevuelto{get;set;}
        //public ProductoDTO Producto{get;set;}
    }
}