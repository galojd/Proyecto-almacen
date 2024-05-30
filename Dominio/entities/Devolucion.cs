using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.entities
{
    public class Devolucion
    {
        public Guid DevolucionId{get;set;}
        public int? Cantidad{get;set;}
        public DateTime? FechaDevolucion{get;set;}
        public string? Descripcion{get;set;}
        public Guid? DetallePedidoId{get;set;}
        public DetallePedido? DetallePedido{get;set;}
        
    }//actualizado
}